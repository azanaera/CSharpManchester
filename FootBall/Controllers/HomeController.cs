﻿using System;
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
        public IActionResult Details(int? id)
        {
            var calculatedMatches = new CalculatedMatches(HttpContext.Request.Cookies["result"]);
            if (id == null)
            {
                return NotFound();
            }

            var team = calculatedMatches.Teams
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
            HttpContext.Response.Cookies.Append("result",result);
            var _calculatedMatches = new CalculatedMatches(result);
            var _teams = _calculatedMatches.Teams;
            return View(_teams);
        }

        public IActionResult ViewTeam(string teamName)
        {
            var _calculatedMatches = new CalculatedMatches(HttpContext.Request.Cookies["result"]);
            var team = _calculatedMatches.GetResults(teamName); // Team object
            return PartialView("_TeamDetail", team);
        }

        public IActionResult CalculateMatch()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
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
