using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Entities;
using SoftwareHouseManagement.Models.Services;

namespace SoftwareHouseManagement.Controllers
{
    public class ComputersController : Controller
    {
        private readonly WorkersService _workersService;
        private readonly SoftwareHouseDbContext _context;
        private readonly ComputersService _computersService;

        public ComputersController(WorkersService workersService, ComputersService computersService, SoftwareHouseDbContext context)
        {
            _workersService = workersService;
            _computersService = computersService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Computers()
        {
            ViewBag.Workers = _workersService.GetAllWithoutComputer();
            ViewBag.Computers = _computersService.GetAllWithoutWorker();
            ViewBag.WorkersWithComputer = _computersService.GetAllWithComputers();
            return View();
        }

        [HttpPost]
        public IActionResult ComputerAdd(string model)
        {
            _computersService.AddComputer(model);
            return RedirectToAction("Computers");
        }

        [HttpPost]
        public IActionResult ComputerAssign(long workerId, long computerId)
        {
            _computersService.AssignComputer(workerId, computerId);
            return RedirectToAction("Computers");
        }

        [HttpGet]
        public IActionResult ComputerAssignedDelete(long workerId)
        {
            _computersService.DeleteAssignedComputers(workerId);
            return RedirectToAction("Computers");
        }
    }
}