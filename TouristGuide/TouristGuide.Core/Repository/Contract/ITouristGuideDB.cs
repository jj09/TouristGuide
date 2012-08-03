using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TouristGuide.Core.Models
{
    public interface ITouristGuideDB
    {
        IDbSet<News> News { get; set; }
        IDbSet<Attraction> Attraction { get; set; }
        IDbSet<AttractionReview> AttractionReview { get; set; }
        IDbSet<AttractionImage> AttractionImage { get; set; }
        IDbSet<AttractionType> AttractionType { get; set; }
        IDbSet<Coordinates> Coordinates { get; set; }
        IDbSet<Country> Country { get; set; }
        IDbSet<Place> Place { get; set; }
        IDbSet<Address> Address { get; set; }
        int SaveChanges();
    }
}