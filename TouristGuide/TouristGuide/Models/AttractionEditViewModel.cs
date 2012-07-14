using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TouristGuide.Models
{
    public class AttractionEditViewModel
    {
        public AttractionEditViewModel()
        {
            NewImages = new List<AttractionImage>();
            //DeleteImages = new List<Int32>();
        }

        public Attraction Attraction { get; set; }
        List<AttractionImage> NewImages { get; set; }
        Int32[] DeleteImages { get; set; }
    }
}