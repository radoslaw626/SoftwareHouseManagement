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
            ViewBag.Positions = _positionService.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult WorkerAdd(string firstName, string lastName, string email, string password, long positionId)
        {
            _workersService.AddWorker(firstName, lastName, email, password, positionId);
            return RedirectToAction("WorkerAdd");
        }
    }
}
