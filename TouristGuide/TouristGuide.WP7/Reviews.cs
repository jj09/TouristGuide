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
    public class Reviews
    {
        public String Author { get; set; }
        public String Date { get; set; }
        public double Rating { get; set; }
        public String Text { get; set; }

        

        public Reviews(String author, String date, double rating, String text)
        {
            this.Author = author;
            this.Date = date;
            this.Rating = rating;
            this.Text = text;
          
        }

    }
}
