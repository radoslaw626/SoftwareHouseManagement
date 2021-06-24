using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SoftwareHouseManagement.Models;
using SoftwareHouseManagement.Models.Services;

namespace SoftwareHouseManagement.Controllers
{
    public class TeamsController : Controller
    {
        private readonly TeamsService _teamsService;
        private readonly WorkersService _workersService;
        private readonly PositionService _positionService;
        private readonly SoftwareHouseDbContext _context;
        

        public TeamsController(TeamsService teamsService, WorkersService workersService, PositionService positionService, SoftwareHouseDbContext context)
        {
            _teamsService = teamsService;
            _workersService = workersService;
            _positionService = positionService;
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Teams()
        {
            try
            {
                ViewBag.AllWorkers = _workersService.GetAll();
                ViewBag.AssignedTeams = _teamsService.GetAllAssignedTeams();
                ViewBag.NotAssignedTeams = _teamsService.GetAllNotAssignedTeams();
                ViewBag.NotAssignedTasks = _teamsService.GetAllNotAssignedTasks();
            }
            catch (Exception)
            {

            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult TeamAdd(string name) 
        {
            _teamsService.AddTeam(name);
            return RedirectToAction("Teams");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult TeamAssignTask(long teamId, long taskId, int hours, int minutes)
        {
            _teamsService.AssignTaskToTeam(teamId,taskId,hours,minutes);
            return RedirectToAction("Teams");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult TeamAssignWorker(long teamId, string workerId)
        {
            _teamsService.AssignWorkerToTeam(teamId, workerId);
            return RedirectToAction("Teams");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Members(long teamId)
        {
            ViewBag.TeamId = teamId;
            var vm = _teamsService.GetTeamsWorkers(teamId);
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteTeamContent(long teamId)
        {
            _teamsService.DeleteTeamContent(teamId);
            return RedirectToAction("Teams");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteFromTeam(long teamId, string workerId)
        {
            _teamsService.DeleteFromTeam(teamId, workerId);
            return RedirectToAction("Members", new {teamId = teamId});
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Accesses(long teamId)
        {
            ViewBag.TeamId = teamId;
            var vm=_teamsService.GetTeamsAccesses(teamId);
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddAccessForTeam(long teamId, string accessName)
        {
            _teamsService.AddAccessForTeam(accessName, teamId);
            return RedirectToAction("Accesses", new {teamId = teamId});
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteAccessFromTeam(long teamId, long accessId)
        {
            _teamsService.DeleteAccessFromTeam(teamId, accessId);
            return RedirectToAction("Accesses", new {teamId = teamId});
        }
    }
}
