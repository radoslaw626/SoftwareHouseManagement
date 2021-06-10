using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test2()
        {
            return View();
        }
        public IActionResult Test3()
        {
            return View();
        }

        public IActionResult Stanowiska()
        {
            var vm = new List<Position>
            {
                new Position()
                {
                    Id = 1,
                    Name = "Programista-Junior",
                    Responsibilities = { },
                    Wage = 25.50m,
                    Workers = { }
                },
                new Position()
                {
                    Id = 2,
                    Name = "Programista-Mid",
                    Responsibilities = { },
                    Wage = 40.0m,
                    Workers = { }
                },
                new Position()
                {
                    Id = 3,
                    Name = "Programista-Senior",
                    Responsibilities = { },
                    Wage = 60.0m,
                    Workers = { }
                },
                new Position()
                {
                    Id = 4,
                    Name = "Kierownik",
                    Responsibilities = { },
                    Wage = 35.0m,
                    Workers = { }
                },
                new Position()
                {
                    Id = 5,
                    Name = "Tester",
                    Responsibilities = { },
                    Wage = 35.0m,
                    Workers = { }
                },

            };
            
            return View(vm);
        }
        public IActionResult Obowiazki()
        {
            var vm = new List<Responsibilities>
            {
                new Responsibilities()
                {
                    Id = 1,
                    Name = "Testowanie Aplikacji",
                    Positions = { }
                },
                new Responsibilities()
                {
                    Id = 2,
                    Name = "Uczestniczenie w spotkaniach z klientem",
                    Positions = { }
                },
                new Responsibilities()
                {
                    Id = 3,
                    Name = "Poprawianie tłumaczeń w aplikacjach",
                    Positions = { }
                }
            };
            return View(vm);
        }

        public IActionResult ModifyObowiązki()
        {
            return View();
        }
        public IActionResult ModifyStanowiska()
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
