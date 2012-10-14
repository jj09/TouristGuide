using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using TouristGuide.Providers.Database;

namespace TouristGuide.Controllers
{
    [Authorize]
    public class MyAttractionController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();
        private IDataProvider users = new SqlProvider();

        //
        // GET: /MyAttraction/
                
        public ViewResult Index()
        {
            var id = users.GetUserByLogin(HttpContext.User.Identity.Name).UserId;
            var myAttractions = db.MyAttractions.Where(x => x.UserId == id).Select(x=>x.AttractionId).ToList(); 
            var attractions = db.Attraction.Where(x => myAttractions.Contains(x.ID)).ToList();
            return View(attractions);
        }

        //
        // POST: /MyAttraction/Create

        public ActionResult Add(int attractionId)
        {
            int userId = users.GetUserByLogin(HttpContext.User.Identity.Name).UserId;
            Attraction attr = db.Attraction.Where(x => x.ID == attractionId).SingleOrDefault();
            MyAttraction myAttr = db.MyAttractions.Where(x=>x.UserId==userId && x.AttractionId==attractionId).SingleOrDefault();
            if (attr != null && myAttr == null)
            {
                MyAttraction myAttraction = new MyAttraction();
                myAttraction.AttractionId = attractionId;
                myAttraction.UserId = userId;
                if (ModelState.IsValid)
                {
                    db.MyAttractions.Add(myAttraction);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(myAttraction);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /MyAttraction/Delete/5

        //[HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {            
            MyAttraction myattraction = db.MyAttractions.Where(x=>x.AttractionId==id).Single();
            db.MyAttractions.Remove(myattraction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}