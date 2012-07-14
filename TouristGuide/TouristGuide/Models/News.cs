using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class News
    {
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string Title { get; set; }     

        [Required]
        [MinLength(20)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
    }
}