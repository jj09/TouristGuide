using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TouristGuide.Core.Models;

namespace TouristGuide.Core.Repository
{
    public class AttractionRepository : IAttractionRepository
    {
        private readonly ITouristGuideDB context;

        public AttractionRepository(ITouristGuideDB context)
        {
            this.context = context;
        }

        public IQueryable<Attraction> All
        {
            get { return context.Attraction; }
        }

        public Attraction Find(int id)
        {
            return context.Attraction.Find(id);
        }

        public IQueryable<Attraction> GetAttractions(string place, int start, int count)
        {
            IQueryable<Attraction> attractions = context.Attraction.Include(c => c.Coordinates).Include(c => c.Country).Include(a => a.Address);

            if (place != null)
            {
                attractions = attractions.Where(p => p.Address.City == place || p.Address.Region == place);
            }

            IQueryable<Attraction> attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count); 
            //.Select(x => new
            //{
            //    ID = x.ID,
            //    Name = x.Name,
            //    AvgRating = x.AvgRating.HasValue ? Math.Round(x.AvgRating.Value, 2) : 0.0
            //});

            return attrs;
        }

        public IQueryable<Attraction> SearchAttractions(string inputText, int start, int count)
        {
            IQueryable<Attraction> attractions = context.Attraction
                .Include(c => c.Coordinates)
                .Include(c => c.Country)
                .Include(a => a.Address)
                .Where(x => x.Name.ToLower().Contains(inputText) || x.Country.Name.ToLower().Contains(inputText) || x.Address.City.ToLower().Contains(inputText));

            IQueryable<Attraction> attrs = attractions.OrderByDescending(x => x.AvgRating).Skip(start).Take(count);

            return attrs;
        }

        public Attraction GetAttractionById(int id)
        {
            return context.Attraction
                .Include(x => x.Address)
                .Include(x => x.Coordinates)
                .Include(x => x.Country)
                .Include(x => x.Images)
                .Include(x => x.Reviews)
                .SingleOrDefault(x => x.ID == id);
        }
    }
}
