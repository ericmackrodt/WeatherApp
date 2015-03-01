﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public interface ISentenceProvider
    {
        Task<SentenceData> GetSentence(BaseWeatherData data);
    }
}
