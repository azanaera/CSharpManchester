using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FootBallGame.Data;
using FootBallGame.Util;

namespace FootBallGame.Controllers
{
    public class MatchController : Controller
    {
        private readonly FootBallMvcContext _context;

        public MatchController(FootBallMvcContext context)
        {
            _context = context;
        }
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string result)
        {
            // TODO: Add insert logic here
            var calculatedMatches = new CalculatedMatches(result);
            var team = calculatedMatches.GetResults("Manchester United");
            foreach (var item in calculatedMatches._teams)
            {
                _context.Add(item);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index),"Teams");
        }

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Match/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Match/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}