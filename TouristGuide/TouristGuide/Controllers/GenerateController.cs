using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class GenerateController : Controller
    {
        private TouristGuideDB db = new TouristGuideDB();

        //
        // GET: /Generate/

        public ActionResult News(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; ++i)
            {
                News news = new News { Date = DateTime.Now, Text = generateRandomText(random.Next(3, 10)), Title = generateRandomString(random.Next(10, 20)) };
                db.News.Add(news);
            }
            db.SaveChanges();
            return RedirectToAction("Index","News");
        }

        public ActionResult Attractions(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; ++i)
            {
                int lat = random.Next(10) > 5 ? 1 : -1;
                int lon = random.Next(10) > 5 ? 1 : -1;
                Attraction attraction = new Attraction();
                attraction.Address = new Address();
                attraction.Address.City = db.Place.OrderBy(x => x.ID).Skip(random.Next(db.Place.Count() - 1)).FirstOrDefault().Name;
                attraction.AttractionType = db.AttractionType.OrderBy(x => x.ID).Skip(random.Next(db.AttractionType.Count() - 1)).FirstOrDefault();
                attraction.Coordinates = new Coordinates(); 
                attraction.Coordinates.Latitude = random.NextDouble() * 90 * lat;
                attraction.Coordinates.Longitude = random.NextDouble() * 180 * lon;
                attraction.Country = db.Country.OrderBy(x => x.ID).Skip(random.Next(db.Country.Count() - 1)).FirstOrDefault();
                attraction.Description = generateRandomText(random.Next(3, 10));
                attraction.Name = "Attraction "+i.ToString();
                db.Attraction.Add(attraction);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Attraction");
        }

        public ActionResult AttractionReviews(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; ++i)
            {
                AttractionReview review = new AttractionReview();
                review.AttractionID = db.Attraction.OrderBy(x => x.ID).Skip(random.Next(db.Attraction.Count() - 1)).FirstOrDefault().ID;
                review.Author = "guest";
                review.Date = DateTime.Now;
                review.Rating = random.Next(1,10);
                review.Text = generateRandomText(2);
                db.AttractionReview.Add(review);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Attraction");
        }
        
        public String generateRandomText(int length)
        {
            //Initiate objects & vars    
            Random random = new Random();
            String randomString = "";

            String [] sentences = new String[]
            {
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.",
                "Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.",
                "Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.",
                "Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.",
                "Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem.",
                "Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius.",
                "Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum.",
                "Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima.",
                "Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.",
                "Co? Dobra!"
            };

            //Loop ‘length’ times to generate a random number or character
            for (int i = 0; i < length; i++)
            {
               //append random char or digit to random string
               randomString = randomString + " " + sentences[random.Next(0,sentences.Length)];
            }
            //return the random string
            return randomString;
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
    }
}
