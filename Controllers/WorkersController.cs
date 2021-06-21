using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
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

        public WorkersController( WorkersService workersService, PositionService positionService, SoftwareHouseDbContext context)
        {
            _workersService = workersService;
            _positionService = positionService;
            _context = context;
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
        public IActionResult WorkerAdd(Worker data, long positionId)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _workersService.AddWorker(data.FirstName, data.LastName, data.Email, data.Password, positionId);
            return RedirectToAction("WorkerAdd");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var vm = new List<Task>
            {
            };

            return View(vm);
        }

        public FileContentResult DownloadCSV()
        {
            var currentUserId = 1;
            var worker = _context.Workers.FirstOrDefault(x => x.Id == currentUserId);
            var position = _context.Positions.FirstOrDefault(y => y.Id == worker.PositionId);
            var currentDate = DateTime.Now;
            var hoursWorked = _context.HoursWorked.Where(z => z.Month < currentDate).Sum(za => za.Amount);

            string csv = $"Imię:, {worker.FirstName}\n" +
                         $"Nazwisko:, {worker.LastName}\n" +
                         $"Email:, {worker.Email}\n" +
                         $"Pozycja:, {position.Name}\n" +
                         $"Stawka:, {position.Wage}\n" +
                         $"Przepracowane godziny:, {hoursWorked}\n" +
                         $"Zarobek:, {hoursWorked * position.Wage}, PLN";
            var data = Encoding.UTF8.GetBytes(csv);
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            return File(result, "text/csv", "PaySlip.csv");
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
