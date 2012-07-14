using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class MyAttraction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AttractionId { get; set; }
    }
}