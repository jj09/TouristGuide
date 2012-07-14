using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

using System.Data.Entity;

namespace TouristGuide.Controllers
{
    public class HomeController : Controller
    {
        public ITouristGuideDB db;

        public HomeController()
        {
            db = new TouristGuideDB();
        }

        public HomeController(ITouristGuideDB dbContext)
        {
            db = dbContext;
        }

        public ActionResult Index(int start=1)
        {
            var news = db.News.Where(n => n.Date <= DateTime.Now).OrderByDescending(n => n.Date).ToList();

            int newsCount = news.Count();
            if (start > newsCount)
                start = newsCount;
            if (start < 1)
                start = 1;

            ViewBag.PagesCount = newsCount / 10 + (newsCount % 10 > 0 ? 1 : 0);
            ViewBag.CurrentPage = ((start - 1) / 10) + 1;

            news = news.Skip(start - 1).Take(10).ToList();

            return View(news);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Mobile()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Map()
        {
            var countries = db.Country.OrderBy(x => x.Name).Include(c => c.Coordinates);
            return View(countries);
        }

        public ActionResult GetCountriesWithCoordinates()
        {
            //Get the data from the database
            var countries = db.Country.OrderBy(x => x.Name).Include(c => c.Coordinates);
            List<PushPinModel> pushpins = new List<PushPinModel>();

            //add info to list of pushpins
            foreach (var country in countries)
            {
                //set the html to pass into the description
                string descriptionHtml;
                if (country.Description.Length > 200)
                    descriptionHtml = country.Description.Substring(0, 200) + "...";
                else
                    descriptionHtml = country.Description;

                //add the pushpin info
                pushpins.Add(new PushPinModel
                {
                    Description = descriptionHtml,
                    Latitude = country.Coordinates.Latitude,
                    Longitude = country.Coordinates.Longitude,
                    Title = "<a href=\"/Country/Details/" + country.ID + "\">" + country.Name + "</a>"
                });
            }

            //return the list as JSON
            return Json(pushpins);
        }
    }
}
