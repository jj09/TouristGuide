using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristGuide.Core.Models
{
    public class PushPinModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}