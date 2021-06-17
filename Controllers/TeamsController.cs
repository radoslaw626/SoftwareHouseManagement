using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Teams()
        {
            return View();
        }
    }
}
