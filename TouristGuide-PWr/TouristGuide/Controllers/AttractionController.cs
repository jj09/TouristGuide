using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Web.Security;
using TouristGuide.Helpers;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TouristGuide.Controllers
{
    public class AttractionController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        #region Attractions
        //
        // GET: /Attraction/

        public ViewResult Index(string country, string place, int start = 0, int count = 20)
        {
            List<Attraction> attractions = FilterAttractions(country, place, null, start, count, "rating", true);
            return View(attractions);
        }

        private List<Attraction> FilterAttractions(string country, string place, string attraction, int start,
            int count, string sort, bool desc)
        {
            IQueryable<Attraction> attractions = db.Attraction;

            if (country != null && country != "")
            {
                attractions = attractions.Where(a => a.Country != null && a.Country.Name.Contains(country));
            }
            if (place != null && place != "")
            {
                attractions = attractions.Where(a => (a.Address.City != null && a.Address.City.Contains(place))
                                                    || (a.Address.Region != null && a.Address.Region.Contains(place)));
            }
            if (attraction != null && attraction != "")
            {
                attractions = attractions.Where(x => x.Name != null && x.Name.Contains(attraction));
            }

            if (sort == "rating")
            {
                attractions = attractions.OrderByWithDirection(x => x.AvgRating, desc);
            }
            else if (sort == "leters")
            {
                attractions = attractions.OrderByWithDirection(x => x.Name, desc);
            }

            return attractions.Skip(start).Take(count).ToList();
        }

        public ViewResult GetAttractions(string country, string place, string attraction, int start, int count,
            string sort, bool desc)
        {
            List<Attraction> attractions = FilterAttractions(country, place, attraction, start, count, sort, desc);
            return View(attractions);
        }

        public ActionResult LookupCountry(String query, int limit = 50)
        {
            List<String> cats = db.Country.Where(x => x.Name.Contains(query)).Take(limit).Select(x => x.Name).ToList();
            var retValue = cats.Select(r => new { Country = r });
            return Json(retValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LookupPlace(String query, int limit = 50)
        {
            List<String> cats = db.Place.Where(x => x.Name.Contains(query)).Take(limit).Select(x => x.Name).ToList();
            var retValue = cats.Select(r => new { Place = r });
            return Json(retValue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LookupAttraction(String query, int limit = 50)
        {
            List<String> cats = db.Attraction.Where(x => x.Name.Contains(query)).Take(limit).Select(x => x.Name).ToList();
            var retValue = cats.Select(r => new { Attraction = r });
            return Json(retValue, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Attraction/Details/5

        public ViewResult Details(int id)
        {
            var num = 10;
            //Attraction attraction = db.Attraction.Find(id);
            //attraction.Reviews = db.AttractionReview.Where(a => a.AttractionID == id).ToList();
            //attraction.Images = db.AttractionImage.Where(a => a.AttractionID == id).ToList();

            var attraction = db.Attraction.Include(i => i.Images).Include(a => a.Address).Include(c => c.Coordinates)
                .Include(c => c.Country).Include(c => c.AttractionType).Where(a => a.ID == id).SingleOrDefault();

            ViewData["Reviews"] = db.AttractionReview.Where(a => a.AttractionID == id).OrderByDescending(x => x.Date)
                .Take(num).ToList();
            return View(attraction);
        }

        public ViewResult GetReviews(int id, int start, int count)
        {
            var rev = db.AttractionReview.Where(a => a.AttractionID == id).OrderByDescending(x => x.Date)
                .Skip(start).Take(count).ToList();
            return View(rev);
        }

        //
        // GET: /Attraction/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.AttractionTypes = DbHelpers.GetAttractionTypesToList();
            ViewBag.Countries = DbHelpers.GetCountriesToList();
            return View();
        }

        //
        // POST: /Attraction/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Attraction attraction)
        {
            attraction.AttractionType = db.AttractionType.Find(attraction.AttractionType.ID);
            attraction.Country = db.Country.Find(attraction.Country.ID);
            attraction.AvgRating = 0.0;

            //upload photos
            try
            {
                int i = 0;
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[i].ContentLength == 0)
                        continue;

                    string path = AppDomain.CurrentDomain.BaseDirectory + "Content/AttractionImages/";
                    string ext = Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'));
                    AttractionImage ai = new AttractionImage { AttractionID = attraction.ID, FileName = generateRandomString(32) + ext };
                    attraction.Images.Add(ai);
                    Request.Files[i].SaveAs(Path.Combine(path, ai.FileName));
                    i++;
                }
            }
            catch (NullReferenceException)
            {
                //no photo
            }
            //end of upload user photo

            db.Attraction.Add(attraction);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = attraction.ID });
        }

        //
        // GET: /Attraction/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.AttractionTypes = DbHelpers.GetAttractionTypesToList();
            ViewBag.Countries = DbHelpers.GetCountriesToList();
            Attraction attraction = db.Attraction.Include(c => c.Country).Include(t => t.AttractionType).Include(c => c.Coordinates).Include(a => a.Address).Include(i => i.Images).Where(a => a.ID == id).SingleOrDefault();
            AttractionEditViewModel attractionEdit = new AttractionEditViewModel();
            attractionEdit.Attraction = attraction;
            return View(attractionEdit);
        }

        //
        // POST: /Attraction/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(AttractionEditViewModel attractionEdit)
        {
            var updatedAttraction = db.Attraction.Include(a => a.AttractionType).Include(c => c.Country).Include(c => c.Coordinates).Include(a => a.Address).Where(x => x.ID == attractionEdit.Attraction.ID).SingleOrDefault();
            updatedAttraction.AttractionType = db.AttractionType.Find(attractionEdit.Attraction.AttractionType.ID);
            updatedAttraction.Country = db.Country.Find(attractionEdit.Attraction.Country.ID);
            updatedAttraction.Coordinates.Latitude = attractionEdit.Attraction.Coordinates.Latitude;
            updatedAttraction.Coordinates.Longitude = attractionEdit.Attraction.Coordinates.Longitude;
            updatedAttraction.Address = attractionEdit.Attraction.Address;
            db.Entry(updatedAttraction).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = updatedAttraction.ID });
        }

        //
        // GET: /Attraction/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Attraction attraction = db.Attraction.Find(id);
            return View(attraction);
        }

        //
        // POST: /Attraction/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Attraction attraction = db.Attraction.Find(id);
            //remove reviews
            var deleteAttractionReviews =
                    from attractions in db.AttractionReview
                    where attractions.AttractionID == id
                    select attractions;

            foreach (var review in deleteAttractionReviews)
            {
                db.AttractionReview.Remove(review);
            }
            //---

            //remove images
            var deleteAttractionImages =
                    from attractions in db.AttractionImage
                    where attractions.AttractionID == id
                    select attractions;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Content/AttractionImages/";
                foreach (var img in deleteAttractionImages)
                {
                    FileInfo TheFile = new FileInfo(path + img.FileName);
                    if (TheFile.Exists)
                    {
                        TheFile.Delete();
                    }
                    db.AttractionImage.Remove(img);
                }
            }
            catch (NullReferenceException)
            {
                //no images
            }
            //---

            db.Attraction.Remove(attraction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion Attractions

        #region Reviews
        ////
        //// GET: /Attraction/

        //public ViewResult ReviewIndex()
        //{
        //    return View(db.Attraction.ToList());
        //}

        ////
        //// GET: /Attraction/Details/5

        //public ViewResult ReviewDetails(int id)
        //{
        //    Attraction attraction = db.Attraction.Find(id);
        //    attraction.Reviews = db.AttractionReview.Where(a => a.AttractionID == id).ToList();
        //    return View(attraction);
        //}

        //
        // POST: /Attraction/ReviewCreate
        [Authorize]
        public ActionResult ReviewCreate(int AttractionId, String Author, int Rating, String Text)
        {
            AttractionReview review = new AttractionReview();
            review.AttractionID = AttractionId;
            review.Author = Author;
            review.Rating = Rating;
            review.Text = Text;
            review.Date = DateTime.Now;

            var attraction = db.Attraction.Include(x => x.AttractionType).Include(x => x.Address).Include(x => x.Coordinates)
                .Include(x => x.Country).SingleOrDefault(x => x.ID == review.AttractionID);

            int reviewsCount = db.AttractionReview.Where(a => a.AttractionID == review.AttractionID).Count();

            if (ModelState.IsValid)
            {
                db.AttractionReview.Add(review);
                attraction.AvgRating = ((attraction.AvgRating * reviewsCount) + review.Rating) / (reviewsCount + 1);
                db.SaveChanges();
            }
            //return RedirectToAction("Details", new { id = review.AttractionID });
            return View("GetReview", review);
        }

        public ActionResult UpdateAvgRatings()
        {
            var attractions = db.Attraction.Include(c => c.Country).Include(c => c.AttractionType).ToList();
            foreach (var attraction in attractions)
            {
                var reviews = db.AttractionReview.Where(a => a.AttractionID == attraction.ID).ToList();
                int ratingSum = 0;
                foreach (var item in reviews)
                {
                    ratingSum += item.Rating;
                }
                if (reviews.Count() > 0)
                    attraction.AvgRating = (double)ratingSum / reviews.Count();
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // GET: /Attraction/ReviewEdit/5
        [Authorize]
        public ActionResult ReviewEdit(int id)
        {

            AttractionReview review = db.AttractionReview.Find(id);
            if (!review.Author.Equals(Membership.GetUser().UserName) && !Roles.IsUserInRole(Membership.GetUser().UserName, "admin"))
                return RedirectToAction("Details", new { id = review.AttractionID });
            ViewBag.Attraction = db.Attraction.Find(review.AttractionID);
            ViewBag.currentRating = review.Rating;
            return View(review);
        }

        //
        // POST: /Attraction/ReviewEdit/5
        [Authorize]
        [HttpPost]
        public ActionResult ReviewEdit(AttractionReview review, int oldRating)
        {
            if (!review.Author.Equals(Membership.GetUser().UserName) && !Roles.IsUserInRole(Membership.GetUser().UserName, "admin"))
                return RedirectToAction("Details", new { id = review.AttractionID });

            db.Entry(review).State = EntityState.Modified;

            //update avg rating
            var attraction = db.Attraction.Include(c => c.Country).Include(c => c.AttractionType)
                .Include(r => r.Reviews).Where(x => x.ID == review.AttractionID).SingleOrDefault();
            int reviewsCount = attraction.Reviews.Count();
            attraction.AvgRating = (attraction.AvgRating * reviewsCount - oldRating + review.Rating) / reviewsCount;
            //end of update

            db.SaveChanges();
            return RedirectToAction("Details", new { id = review.AttractionID });
        }

        //
        // GET: /Attraction/ReviewDelete/5
        [Authorize]
        public ActionResult ReviewDelete(int id)
        {
            AttractionReview review = db.AttractionReview.Find(id);
            if (!review.Author.Equals(Membership.GetUser().UserName) && !Roles.IsUserInRole(Membership.GetUser().UserName, "admin"))
                return RedirectToAction("Details", new { id = review.AttractionID });
            ViewBag.Attraction = db.Attraction.Find(review.AttractionID);
            return View(review);
        }

        //
        // POST: /Attraction/ReviewDelete/5
        [Authorize]
        [HttpPost, ActionName("ReviewDelete")]
        public ActionResult ReviewDeleteConfirmed(int id)
        {
            AttractionReview review = db.AttractionReview.Find(id);
            if (!review.Author.Equals(Membership.GetUser().UserName) && !Roles.IsUserInRole(Membership.GetUser().UserName, "admin"))
                return RedirectToAction("Details", new { id = review.AttractionID });
            //update avg rating
            var attraction = db.Attraction.Include(c => c.Country).Include(c => c.AttractionType)
                .Include(r => r.Reviews).Where(x => x.ID == review.AttractionID).SingleOrDefault();
            int reviewsCount = attraction.Reviews.Count();
            attraction.AvgRating = (attraction.AvgRating * reviewsCount - review.Rating) / (reviewsCount - 1);
            //end of update
            db.AttractionReview.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = review.AttractionID });
        }

        #endregion

        #region Helpers

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public String generateRandomString(int length)
        {
            //Initiate objects & vars    
            Random random = new Random();
            String randomString = "";
            int randNumber;

            //Loop ‘length’ times to generate a random number or character
            for (int i = 0; i < length; i++)
            {
                if (random.Next(1, 3) == 1)
                    randNumber = random.Next(97, 123); //char {a-z}
                else
                    randNumber = random.Next(48, 58); //int {0-9}

                //append random char or digit to random string
                randomString = randomString + (char)randNumber;
            }
            //return the random string
            return randomString;
        }

        #endregion Helpers
    }

}