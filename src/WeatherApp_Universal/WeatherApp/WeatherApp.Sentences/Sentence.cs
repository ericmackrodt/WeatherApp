using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp.Sentences
{
    public class Sentence
    {
        public string Phrase { get; set; }
        public string SubText { get; set; }
        public string Color { get; set; }
        public WeatherType? Condition { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
    }
}
