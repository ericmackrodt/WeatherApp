using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Sentences
{
    public interface ISentenceProvider
    {
        Sentence GetSentence(WeatherType? weatherType = null, double? maxTemp = null, double? minTemp = null);
    }
}
