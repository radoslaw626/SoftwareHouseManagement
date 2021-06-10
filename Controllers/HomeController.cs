using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareHouseManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SoftwareHouseManagement.Models.Entities;


namespace SoftwareHouseManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new List<Task>
            {
                new Task()
                {
                    Id = 1,
                    AssignedHours = new TimeSpan(0,50,0,0),
                    WorkedHours = new TimeSpan(0,12,0,0),
                    Client = new Client(),
                    ClientId = 1,
                    Subject = "Strona A",
                    Team = new Team()
                },
                new Task()
                {
                    Id = 2,
                    AssignedHours = new TimeSpan(0,80,0,0),
                    WorkedHours = new TimeSpan(0,12,0,0),
                    Client = new Client(),
                    ClientId = 1,
                    Subject = "Strona B",
                    Team = new Team()
                },
                new Task()
                {
                    Id = 3,
                    AssignedHours = new TimeSpan(0,60,0,0),
                    WorkedHours = new TimeSpan(0,12,0,0),
                    Client = new Client(),
                    ClientId = 1,
                    Subject = "Strona C",
                    Team = new Team()
                },


            };


            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult DodajZlecenie()
        {
            return View();
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
