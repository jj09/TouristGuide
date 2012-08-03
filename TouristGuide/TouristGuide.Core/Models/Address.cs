using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Core.Models
{
    public class Address
    {
        public int ID { get; set; }

        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        [Display(Name = "Building number")]
        public int? BuildingNumber { get; set; }
        public Country Country { get; set; }
    }
}