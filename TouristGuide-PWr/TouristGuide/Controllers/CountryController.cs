using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Text.RegularExpressions;

namespace TouristGuide.Controllers
{ 
    public class CountryController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        //
        // GET: /Country/

        public ViewResult Index(int start = 0, int count = 20)
        {
            List<Country> countries = FilterCountries(null, start, count);
            return View(countries);
        }

        private List<Country> FilterCountries(string country, int start, int count)
        {
            IQueryable<Country> countries = db.Country;

            if (country != null && country != "")
            {
                countries = countries.Where(a => a.Name.Contains(country));
            }
            
            return countries.OrderBy(x => x.Name).Skip(start).Take(count).ToList();
        }

        public ViewResult GetCountries(string country, int start, int count)
        {
            List<Country> countries = FilterCountries(country, start, count);
            return View(countries);
        }

        //
        // GET: /Country/Details/5

        public ViewResult Details(int id)
        {
            Country country = db.Country.Include(c => c.Coordinates).Where(x => x.ID == id).Single();
            return View(country);
        }

        //
        // GET: /Country/Create
        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Country/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Country.Add(country);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = country.ID });
            }

            return View(country);
        }
        
        //
        // GET: /Country/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Country country = db.Country.Find(id);
            return View(country);
        }

        //
        // POST: /Country/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = country.ID });
            }
            return View(country);
        }

        //
        // GET: /Country/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Country country = db.Country.Find(id);
            return View(country);
        }

        //
        // POST: /Country/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AttractionsForCountry(string country)
        {
            //Get the data from the database
            var places = db.Place.Where(x => x.Country.Name == country).Include(c => c.Coordinates).Take(100);
            List<PushPinModel> pushpins = new List<PushPinModel>();

            //add info to list of pushpins
            foreach (var place in places)
            {
                //set the html to pass into the description
                string descriptionHtml;
                if (place.Description.Length > 200)
                {
                    descriptionHtml = Regex.Replace(place.Description, @"<.*?>", string.Empty);
                    descriptionHtml = descriptionHtml.Substring(0, 200) + "...";
                }
                else
                    descriptionHtml = place.Description;

                //add the pushpin info
                pushpins.Add(new PushPinModel
                {
                    Description = descriptionHtml,
                    Latitude = place.Coordinates.Latitude,
                    Longitude = place.Coordinates.Longitude,
                    Title = "<a href=\"/Place/Details/" + place.ID + "\">" + place.Name + "</a>"
                });
            }

            //return the list as JSON
            return Json(pushpins);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}