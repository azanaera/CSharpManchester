using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FootBall.Models;

namespace FootBall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Team> _teams;
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teams
                .FirstOrDefault(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
        [HttpPost]
        public IActionResult CalculateMatch(string result)
        {
            var calculatedMatches = new CalculatedMatches(result);
            _teams = calculatedMatches._teams;
            return View(nameof(Index), _teams);
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CalculateMatch()
        {
            return View();
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
    }
}
