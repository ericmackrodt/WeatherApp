using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;

namespace WeatherApp.Common
{
    public class WittySentencesProvider : ISentencesProvider
    {
        public Sentences GetSentence(Provider.SemanticWeatherEnum semanticWeather)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader("WittySentences");
            var keyFormat = "{0}_{1}";
            var subKeyFormat = "{0}_Sub_{1}";

            var sentencesList = new Dictionary<string, string>();
            var subSentencesList = new Dictionary<string, string>();
            for (int i = 0; i < 10; i++)
            {
                var key = string.Format(keyFormat, semanticWeather.ToString(), i);
                var subKey = string.Format(subKeyFormat, semanticWeather.ToString(), i);
                var value = loader.GetString(key);
                var subValue = loader.GetString(subKey);
                if (!string.IsNullOrWhiteSpace(value))
                    sentencesList.Add(key, value);
                if (!string.IsNullOrWhiteSpace(subValue))
                    subSentencesList.Add(subKey, subValue);
            }

            var random = new Random().Next(0, sentencesList.Count - 1);

            if (sentencesList.Count == 0)
            {
                return new Sentences()
                {
                    Sentence = loader.GetString("Unknown"),
                    SubSentence = loader.GetString("Unknown_Sub")
                };
            }

            var currentValue = sentencesList[string.Format(keyFormat, semanticWeather.ToString(), random)];
            var currentSubValue = subSentencesList[string.Format(subKeyFormat, semanticWeather.ToString(), random)];

            return new Sentences()
            {
                Sentence = currentValue,
                SubSentence = currentSubValue
            };
        }
    }
}
