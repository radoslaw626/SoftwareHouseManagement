using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Entities;
using SoftwareHouseManagement.Models.Services;

namespace SoftwareHouseManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ResponsibilitiesService _responsibilitiesService;
        private readonly PositionService _positionService;
        private  readonly SoftwareHouseDbContext _context;

        public AdminController(ResponsibilitiesService responsibilitiesService, PositionService positionService, SoftwareHouseDbContext context)
        {
            _responsibilitiesService = responsibilitiesService;
            _positionService = positionService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test3()
        {
            return View();
        }

        

        public IActionResult Teams()
        {
            return View();
        }
        public IActionResult AssignComputer()
        {
            return View();
        }
    }
}
