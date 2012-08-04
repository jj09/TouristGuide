using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TouristGuide.Core.Repository;
using TouristGuide.Core.Models;

namespace TouristGuide.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WPService" in code, svc and config file together.
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
