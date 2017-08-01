using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildlifeTracker.Models;

namespace WildlifeTracker.Controllers
{
    public class SightingController : Controller
    {
        private WildlifeTrackerContext db = new WildlifeTrackerContext();
        public IActionResult Index()
        {
            return View(db.Sighting.Include(sighting => sighting.Species).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisSighting = db.Sighting.FirstOrDefault(sighting => sighting.SightingId == id);
            return View(thisSighting);
        }

        public IActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sighting sighting)
        {
            db.Sighting.Add(sighting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisSighting = db.Sighting.FirstOrDefault(sighting => sighting.SightingId == id);
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "Name");
            return View(thisSighting);
        }

        [HttpPost]
        public IActionResult Edit(Sighting sighting)
        {
            db.Entry(sighting).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisSighting = db.Sighting.FirstOrDefault(sighting => sighting.SightingId == id);
            return View(thisSighting);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisSighting = db.Sighting.FirstOrDefault(sighting => sighting.SightingId == id);
            db.Sighting.Remove(thisSighting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
