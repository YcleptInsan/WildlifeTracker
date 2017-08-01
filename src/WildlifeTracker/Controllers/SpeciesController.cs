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
    public class SpeciesController : Controller
    {
        private WildlifeTrackerContext db = new WildlifeTrackerContext();
        public IActionResult Index()
        {
            return View(db.Species.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.SpeciesId == id);

            try
            {

                var sightings = db.Sighting
                    .Where(sighting => sighting.SpeciesId == id)
                    .ToList();

                ViewBag.Sighting = new SelectList(sightings, "SpeciesId", "Date");

                return View(thisSpecies);
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View(thisSpecies);
            }
    
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Species species)
        {
            db.Species.Add(species);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.SpeciesId == id);
            return View(thisSpecies);
        }

        [HttpPost]
        public IActionResult Edit(Species species)
        {
            db.Entry(species).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.SpeciesId == id);
            return View(thisSpecies);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.SpeciesId == id);
            db.Species.Remove(thisSpecies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
