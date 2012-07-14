using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;

namespace TouristGuide.Helpers
{
    public static class DbHelpers
    {
        private static TouristGuideDB db = new TouristGuideDB();

        public static List<SelectListItem> GetAttractionTypesToList()
        {
            List<SelectListItem> attractionTypes = new List<SelectListItem>();
            var allAttractionTypes = db.AttractionType;
            foreach (var item in allAttractionTypes)
            {
                attractionTypes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ID.ToString()
                });
            }
            return attractionTypes;
        }

        public static List<SelectListItem> GetCountriesToList()
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            var allCountries = db.Country;
            foreach (var item in allCountries)
            {
                countries.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ID.ToString()
                });
            }
            return countries;
        }
    }
}