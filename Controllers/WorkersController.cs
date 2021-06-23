using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftwareHouseManagement.Helpers;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Entities;
using SoftwareHouseManagement.Models.Services;
using Task = SoftwareHouseManagement.Models.Entities.Task;

namespace SoftwareHouseManagement.Controllers
{
    public class WorkersController : Controller
    {

        private readonly WorkersService _workersService;
        private readonly PositionService _positionService;
        private readonly SoftwareHouseDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;

        public WorkersController( WorkersService workersService, PositionService positionService, SoftwareHouseDbContext context, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            _workersService = workersService;
            _positionService = positionService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult WorkerAdd()
        {
            try
            {
            ViewBag.Positions = _positionService.GetAll();
            }
            catch (Exception)
            {
            }

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> WorkerAdd(Worker data, long positionId)
        {
            var worker = new Worker
            {
                UserName = data.Email,
                Email = data.Email,
                PositionId = positionId,
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            var inserted = await _userManager.CreateAsync(worker, data.PasswordHash);
            if (inserted.Succeeded)
            {
                await _signInManager.SignInAsync(worker, isPersistent: false);

                return RedirectToAction("WorkerAdd");
            }

            foreach (var error in inserted.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            return RedirectToAction("WorkerAdd");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;

            if (identity.PositionId != null)
            {
                ViewBag.Position = _context.Positions.FirstOrDefault(x => x.Id == identity.PositionId);
            }
            else
            {
                ViewBag.Position = new Position();
            }

            if (identity.ComputerId != null)
            {
                ViewBag.Computer = _context.Computers
                    .FirstOrDefault(y => y.Id == identity.ComputerId);
            }
            else
            {
                ViewBag.Computer = new Computer();
            }

            var worker = _context.Workers.Include(ha => ha.HoursWorked).FirstOrDefault(hb => hb.Id == identity.Id);
            if (identity.Teams != null)
            {
                var workerTaskInclude = _context.Workers.Include(a => a.Teams).ThenInclude(b => b.Task).Include(d=>d.Teams).ThenInclude(e=>e.Accesses)
                    .FirstOrDefault(c => c.Id == identity.Id);
                ViewBag.Teams = workerTaskInclude.Teams;
            }
            return View(identity);

        }

        public FileContentResult DownloadCSV()
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var worker = _context.Workers.FirstOrDefault(x => x.Id == identity.Id);
            var position = _context.Positions.FirstOrDefault(y => y.Id == worker.PositionId);
            var currentDate = DateTime.Now;
            var first = new DateTime(currentDate.Year, currentDate.Month, 1);
            var hoursWorkedTicks = _context.HoursWorked.Where(z => z.Month < currentDate & z.Month >=first & z.WorkerId==identity.Id).Sum(za => za.Amount);
            var timeSpanW = TimeSpan.FromTicks(hoursWorkedTicks);
            var hoursWorkedString= string.Format($"{(int)timeSpanW.TotalHours}:{timeSpanW:mm}");
            var hoursInt = hoursWorkedTicks / 36000000000;

            string csv = $"Imię:, {worker.FirstName}\n" +
                         $"Nazwisko:, {worker.LastName}\n" +
                         $"Email:, {worker.Email}\n" +
                         $"Pozycja:, {position.Name}\n" +
                         $"Stawka:, {position.Wage}, PLN\n" +
                         $"Przepracowane godziny:, {hoursWorkedString},h\n" +
                         $"Zarobek:, {hoursInt * position.Wage}, PLN";
            var data = Encoding.UTF8.GetBytes(csv);
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            return File(result, "text/csv", "PaySlip.csv");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel data)
        {
            var worker = new Worker
            {
                UserName = data.Email,
                Email = data.Email
            };

            var inserted = await _userManager.CreateAsync(worker, data.Password);
            if (inserted.Succeeded)
            {
                await _signInManager.SignInAsync(worker, isPersistent: false);

                return RedirectToAction("Login", "Workers");
            }

            foreach (var error in inserted.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(data);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Workers");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            var identity =   _userManager.FindByEmailAsync(User.Identity.Name).Result;
            return View(identity);
        }

        [HttpGet]
        public IActionResult LoginTime()
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            ViewBag.WorkersTasks = _workersService.GetWorkersTasks(identity.Id);
            return View();
        }

        [HttpPost]
        public IActionResult LoginTime(long projectId, string date, int hours, int minutes)
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            _workersService.LoginTime(projectId, date, hours, minutes, identity);
            return RedirectToAction("LoginTime");
        }

        [HttpGet]
        public IActionResult TeamAccesses(long teamId)
        {
            ViewBag.Accesses = _context.Teams.Include(x => x.Accesses).FirstOrDefault(y => y.Id == teamId).Accesses;
            return View();
        }
    }
}
