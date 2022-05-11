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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        RoleManager<IdentityRole> _roleManager;
        private readonly WorkersService _workersService;
        private readonly PositionService _positionService;
        private readonly SoftwareHouseDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;

        public WorkersController( WorkersService workersService, PositionService positionService, SoftwareHouseDbContext context, UserManager<Worker> userManager, SignInManager<Worker> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _workersService = workersService;
            _positionService = positionService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            var position = _context.Positions
                .FirstOrDefault(x => x.Id == positionId);
            var worker = new Worker
            {
                UserName = data.Email,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName
            };
            worker.Positions.Add(position);

            var inserted = await _userManager.CreateAsync(worker, data.PasswordHash);
            if (inserted.Succeeded)
            {
                var result1 = await _userManager.AddToRoleAsync(worker, "Worker");

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
        [Authorize]
        [HttpGet]
        public IActionResult Dashboard()
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var RolesForUser =  _userManager.GetRolesAsync(identity).Result;
            var worker = _context.Workers.Include(ha => ha.HoursWorked).FirstOrDefault(hb => hb.Id == identity.Id);
            if (RolesForUser[0] == "Client")
            {
                return RedirectToAction("AddTask", "Client");
            }
            if (identity.Positions != null)
            {
                var workerPositionsInclude = _context.Workers.Include(a => a.Positions)
                    .FirstOrDefault(c => c.Id == identity.Id);
                ViewBag.Positions = workerPositionsInclude.Positions;
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
                ViewBag.Computer = new Computer("brak");
            }


            if (identity.Teams != null)
            {
                var workerTaskInclude = _context.Workers.Include(a => a.Teams).ThenInclude(b => b.Task).Include(d=>d.Teams).ThenInclude(e=>e.Accesses)
                    .FirstOrDefault(c => c.Id == identity.Id);
                ViewBag.Teams = workerTaskInclude.Teams;
            }
            return View(identity);

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
                var result1 = await _userManager.AddToRoleAsync(worker, "Client");
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
            try
            {
            ViewBag.Accesses = _context.Teams.Include(x => x.Accesses).FirstOrDefault(y => y.Id == teamId).Accesses;
            }
            catch (Exception )
            {
            }

            return View();
        }
    }
}
