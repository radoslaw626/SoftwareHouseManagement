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
        private readonly SoftwareHouseDbContext _context;

        public WorkersController( WorkersService workersService, SoftwareHouseDbContext context)
        {
            _workersService = workersService;
            _context = context;
        }

        [HttpGet]
        public IActionResult WorkerAdd()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult WorkerAdd(string firstName, string lastName, string email, string password)
        {
            //_workersService.AddWorker(firstName, lastName, email, password);
            return RedirectToAction("WorkerAdd");
        }
    }
}
