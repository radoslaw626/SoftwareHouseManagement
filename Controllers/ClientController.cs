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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Task = SoftwareHouseManagement.Models.Entities.Task;


namespace SoftwareHouseManagement.Controllers
{
    public class ClientController : Controller
    {
        private readonly SoftwareHouseDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public ClientController(SoftwareHouseDbContext context, UserManager<Worker> userManager)
        {
            _context = context;
            _userManager=userManager;
        }
        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
        [Authorize(Roles = "Client")]
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

        public async Task<IActionResult> Index()
        {
            var identity = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var RolesForUser = await _userManager.GetRolesAsync(identity);
            
            return View(RolesForUser);
        }
    }
}
