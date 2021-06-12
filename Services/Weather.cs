using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SECO_Weather.Models;

namespace SECO_Weather.Services
{
    interface IWeather
    {
        WeatherDTO WeatherDetail(string City);
    }
}
