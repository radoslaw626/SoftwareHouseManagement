using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareHouseManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SoftwareHouseManagement.Models.Entities;
using SoftwareHouseManagement.Models.Services;
using System.Globalization;


namespace SoftwareHouseManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SoftwareHouseDbContext _context;

        public HomeController(ILogger<HomeController> logger, SoftwareHouseDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(string taskSubject)
        {
            var task = new Task()
            {
                Subject = taskSubject,
                ClientId = 1
            }; 
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return View();
        }
        

    }
}
