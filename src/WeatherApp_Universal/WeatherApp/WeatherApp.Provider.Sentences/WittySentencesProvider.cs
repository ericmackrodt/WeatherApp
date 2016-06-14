using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace WeatherApp.Provider.Sentences
{
    public class WittySentencesProvider : BaseSentenceProvider
    {
        protected override async Task<string> GetSentencesJson()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream("WeatherApp.Provider.Sentences.Strings.WittySentences.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }

        }
    }
}
