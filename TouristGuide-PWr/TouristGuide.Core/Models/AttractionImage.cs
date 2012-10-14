using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Core.Models
{
    public class AttractionImage
    {
        public int ID { get; set; }

        public int AttractionID { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
