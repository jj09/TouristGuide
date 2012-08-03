using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Core.Models
{
    public class AttractionReview
    {
        public int ID { get; set; }
        public int AttractionID { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Range(1,10)]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(10)]
        public string Text { get; set; }
        
    }
}