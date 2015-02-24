﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace WeatherApp.Common
{
    public class LocationProvider : ILocationProvider
    {
        public async Task<Geocoordinate> GetLocation()
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            locator.DesiredAccuracy = PositionAccuracy.High;

            try
            {
                var position = await locator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(10));
                return position.Coordinate;
            }
            catch
            {
                return null;
            }
        }
    }
}