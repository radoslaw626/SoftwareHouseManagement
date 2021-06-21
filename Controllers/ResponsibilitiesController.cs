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
    public class ResponsibilitiesController : Controller
    {
        private readonly ResponsibilitiesService _responsibilitiesService;
        private readonly SoftwareHouseDbContext _context;

        public ResponsibilitiesController(ResponsibilitiesService responsibilitiesService, SoftwareHouseDbContext context)
        {
            _responsibilitiesService = responsibilitiesService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Responsibilities(int id)
        {

            try
            {
                ViewBag.Responsibilities = _responsibilitiesService.GetAll();
                ViewBag.PositionId = id;
                var position = _context.Positions.Include("Responsibilities").FirstOrDefault(x => x.Id == id);
                ViewBag.AssignedResponsibilities = position.Responsibilities;
                ViewBag.PositionName = position.Name;
            }
            catch (Exception)
            {
            }
            return View();
        }

        [HttpPost]
        public IActionResult ResponsibilitiesCreateNew(string Name, long PositionId)
        {
            _responsibilitiesService.CreateResponsibilities(Name);
            return RedirectToAction("Responsibilities", new { id = PositionId });
        }

        [HttpPost]
        public IActionResult ResponsibilitiesAssign(long responsibilityID, long PositionId)
        {
            _responsibilitiesService.AssignResponsibilities(responsibilityID, PositionId);
            return RedirectToAction("Responsibilities", new { id = PositionId });
        }

        [HttpGet]
        public IActionResult ResponsibilitiesModify(long id, long positionId)
        {
            var responsiblity = new Responsibilities();
            try
            {
                ViewBag.PositionId = positionId;
                responsiblity = _context.Responsibilities.FirstOrDefault(x => x.Id == id);

            }
            catch (Exception)
            {

            }
            return View(responsiblity);
        }

        [HttpPost]
        public IActionResult ResponsibilitiesModify(long id, string name, long positionId)
        {
            _responsibilitiesService.ModifyResponsibility(id, name);
            return RedirectToAction("Responsibilities", new { id = positionId });
        }

        [HttpGet]
        public IActionResult ResponsibilityDelete(long responsibilityId, long positionId)
        {
            try
            {
                _responsibilitiesService.DeleteResponsibility(responsibilityId, positionId);
            }
            catch (Exception)
            {

            }

            return RedirectToAction("Responsibilities", new { id = positionId });
        }
    }
}
