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

using ImageTools.IO.Gif;
using ImageTools;

namespace GoogleWeatherWP7
{
    public class WeatherInfo
    {
        public string day_of_week { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string temp_c { get; set; }
        public ExtendedImage icon { get; set; }
        public string condition { get; set; }
    }
}
