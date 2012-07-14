using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TouristGuide.Models;
using System.Data.Entity;
using System.Reflection;
using TouristGuide.Tests.Models;

namespace TouristGuide.Tests.Models
{
    public class MockTouristGuideDB : ITouristGuideDB
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

        public bool saved = false;

        public MockTouristGuideDB()
        {
            // Set up your collections
            News = new MockDbSet<News>();
            Attraction = new MockDbSet<Attraction>();
            AttractionReview = new MockDbSet<AttractionReview>();
            AttractionImage = new MockDbSet<AttractionImage>();
            AttractionType = new MockDbSet<AttractionType>();
            Coordinates = new MockDbSet<Coordinates>();
            Country = new MockDbSet<Country>();
            Place = new MockDbSet<Place>();
            Address = new MockDbSet<Address>();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            foreach (PropertyInfo property in typeof(MockTouristGuideDB).GetProperties())
            {
                if (property.PropertyType == typeof(IDbSet<T>))
                    return property.GetValue(this, null) as IDbSet<T>;
            }
            throw new Exception("Type collection not found");
        }

        public virtual int SaveChanges()
        {
            saved = true;
            return 0;
        }        
    }

}
