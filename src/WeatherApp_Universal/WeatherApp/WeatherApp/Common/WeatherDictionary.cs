using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Provider;

namespace WeatherApp.Common
{
    public class WeatherDictionary<T>
    {
        private Dictionary<KeyValuePair<WeatherConditionType, TimeOfDay>, T> icons;

        public T this[WeatherConditionType weather, TimeOfDay timeOfDay]
        {
            get
            {
                return icons.FirstOrDefault(o => o.Key.Key == weather && o.Key.Value == timeOfDay).Value;
            }
        }
        
        public WeatherDictionary()
        {
            icons = new Dictionary<KeyValuePair<WeatherConditionType, TimeOfDay>, T>();
        }

        public void Add(WeatherConditionType weather, TimeOfDay time, T value)
        {
            icons.Add(new KeyValuePair<WeatherConditionType, TimeOfDay>(weather, time), value);
        }
    }
}
