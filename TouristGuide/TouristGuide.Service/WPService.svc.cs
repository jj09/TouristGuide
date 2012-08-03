using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using TouristGuide.Core.Repository;
using TouristGuide.Core.Models;

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

        public string Name()
        {
            return "WP7 Service";
        }
    }
}
