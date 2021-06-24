using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Entities;
using SoftwareHouseManagement.Models.Services;

namespace SoftwareHouseManagement.Controllers
{
    public class PositionsController : Controller
    {
        private readonly PositionService _positionService;
        private readonly SoftwareHouseDbContext _context;

        public PositionsController( PositionService positionService, SoftwareHouseDbContext context)
        {
            _positionService = positionService;
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Positions()
        {
            try
            {
            ViewBag.Positions = _positionService.GetAll();
            }
            catch (Exception )
            {
            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult PositionCreateNew(string Name, decimal Wage)
        {
            _positionService.CreatePosition(Name, Wage);
            return RedirectToAction("Positions");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult PositionModify(long id)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);
            return View(position);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult PositionModify(long id, string name, decimal wage)
        {
            _positionService.ModifyPosition(id, name, wage);
            return RedirectToAction("Positions");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult PositionDelete(long id)
        {
            _positionService.DeletePosition(id);
            return RedirectToAction("Positions");
        }
    }
}
