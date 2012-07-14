using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.Models;
using System.Web.Security;
using TouristGuide.Helpers;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Models
{
    public class AttractionImage
    {
        public int ID { get; set; }

        public int AttractionID { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
