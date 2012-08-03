using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TouristGuide.Core.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public Coordinates Coordinates { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }
    }
}