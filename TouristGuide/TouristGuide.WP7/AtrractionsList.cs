using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace First_WPA
{
    public class AtrractionsList
    {
        public String Title {get; set;}
        public String Description { get; set; }
        public String Type { get; set; }

        public AtrractionsList(String title, String description, String type)
        {
            this.Title = title;
            this.Description = description;
            switch (type)
            {
                case "Place":
                    this.Type = "Images/place.png";
                    break;
                case "Monument":
                     this.Type = "Images/monument.png";
                    break;
                case "Church":
                    this.Type = "Images/church.png";
                    break;
                case "Square":
                    this.Type = "Images/square.png";
                    break;
  
            }
        }


    }
}
