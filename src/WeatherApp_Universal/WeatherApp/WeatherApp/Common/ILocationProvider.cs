using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace WeatherApp.Common
{
    public interface ILocationProvider
    {
        Task<Geocoordinate> GetLocation();
    }
}
