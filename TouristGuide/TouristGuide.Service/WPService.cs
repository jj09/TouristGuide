using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TouristGuide.Core.Models;
using TouristGuide.Core.Repository;

namespace TouristGuide.Service
{
    public class WPService : IWPService
    {
        private readonly IAttractionRepository attractionRepository;

        public WPService()
        {
            this.attractionRepository = new AttractionRepository(new TouristGuideDB());
        }

        public WPService(IAttractionRepository attractionRepository)
        {
            this.attractionRepository = attractionRepository;
        }

        public List<Attraction> GetAttractions(string place, int start, int count)
        {
            return attractionRepository.GetAttractions(place, start, count).OrderByDescending(x => x.AvgRating).ToList();
        }
    }
}
