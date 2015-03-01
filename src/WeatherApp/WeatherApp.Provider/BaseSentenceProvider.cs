using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public abstract class BaseSentenceProvider : ISentenceProvider
    {
        public virtual async Task<SentenceData> GetSentence(BaseWeatherData data)
        {
            var json = await GetSentencesJson();
            var jsonObject = JsonConvert.DeserializeObject<SentenceData[]>(json);

            return ProcessSentenceData(data, jsonObject);
        }

        protected abstract Task<string> GetSentencesJson();

        private SentenceData ProcessSentenceData(BaseWeatherData data, SentenceData[] sentences)
        {
            SentenceData[] selectedSentences = null;
            var byType = sentences.Where(o => o.Condition == data.SemanticWeather.ToString());
            if (byType == null || !byType.Any())
                byType = sentences;
            
            var temperature = data.FeelsLikeTemperature;

            var byTemperature = byType.Where(o => o.Min != null && o.Max != null && temperature >= o.Min && temperature <= o.Max);

            if (byTemperature == null || !byTemperature.Any())
                byTemperature = byType.Where(o => (o.Min != null && temperature >= o.Min) || (o.Max != null && temperature <= o.Max)).ToArray();

            if (byTemperature != null && byTemperature.Any())
                selectedSentences = byTemperature.ToArray();
            else if (byType != null && byType.Any())
                selectedSentences = byType.ToArray();
            else
                return sentences.FirstOrDefault(o => o.Condition == "Unknown");

            var random = new Random().Next(0, selectedSentences.Length - 1);
            return selectedSentences[random];
        }
    }
}
