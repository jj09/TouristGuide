using System;
using System.Linq;
using TouristGuide.Core.Models;
using System.Collections.Generic;
namespace TouristGuide.Core.Repository
{
    public interface IAttractionRepository
    {
        IQueryable<Attraction> All { get; }

        Attraction Find(int id);

        IQueryable<Attraction> GetAttractions(string place, int start, int count);

        IQueryable<Attraction> SearchAttractions(string inputText, int start, int count);

        Attraction GetAttractionById(int id);
    }
}
