using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;

namespace WeatherApp.Common
{
    public interface ISentencesProvider
    {
        Sentences GetSentence(SemanticWeatherEnum semanticWeather);
    }

    public class Sentences
    {
        public string Sentence { get; set; }
        public string SubSentence { get; set; }
    }
}
