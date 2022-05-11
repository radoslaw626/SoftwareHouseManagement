using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            try
            { 
                ViewBag.Workers = _workersService.GetAllWithoutComputer();
                ViewBag.Computers = _computersService.GetAllWithoutWorker();
                ViewBag.WorkersWithComputer = _computersService.GetAllWithComputers();

            }
            catch (Exception)
            {
            }

            return View();
        }

        [HttpPost]
        public IActionResult ComputerAdd(string model)
        {
            _computersService.AddComputer(model);
            return RedirectToAction("Computers");
        }

        [HttpPost]
        public IActionResult ComputerAssign(string workerId, long computerId)
        {
            _computersService.AssignComputer(workerId, computerId);
            return RedirectToAction("Computers");
        }

        [HttpGet]
        public IActionResult ComputerAssignedDelete(string workerId)
        {
            _computersService.DeleteAssignedComputers(workerId);
            return RedirectToAction("Computers");
        }

    }
}