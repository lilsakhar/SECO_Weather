using SECO_Weather.Models;

namespace SECO_Weather.Services
{
    interface IWeather
    {
        DTO WeatherDetail(string City);
    }
}
