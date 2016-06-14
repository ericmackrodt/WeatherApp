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
            IEnumerable<SentenceData> selectedSentences = null;

            var temperature = data.Temperature;
            selectedSentences = sentences.Where(o => (o.Min == null && o.Max == null) || (temperature >= o.Min && temperature <= o.Max));
            
            var byCondition = selectedSentences.Where(o => o.Condition == data.ConditionType.ToString());
            if (byCondition == null || !byCondition.Any())
                selectedSentences = selectedSentences.Where(o => o.Condition == null);
            else
                selectedSentences = byCondition;

            return selectedSentences.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }
    }
}
