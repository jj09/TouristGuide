using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TouristGuide.Models
{
    public class TouristGuideDB : DbContext, ITouristGuideDB
    {
        public IDbSet<News> News { get; set; }
        public IDbSet<Attraction> Attraction { get; set; }
        public IDbSet<AttractionReview> AttractionReview { get; set; }
        public IDbSet<AttractionImage> AttractionImage { get; set; }
        public IDbSet<AttractionType> AttractionType { get; set; }
        public IDbSet<Coordinates> Coordinates { get; set; }
        public IDbSet<Country> Country { get; set; }
        public IDbSet<Place> Place { get; set; }
        public IDbSet<Address> Address { get; set; }

        public DbSet<MyAttraction> MyAttractions { get; set; }
    }
}