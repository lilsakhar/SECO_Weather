using Microsoft.AspNetCore.Mvc;
using SECO_Weather.Models;
using SECO_Weather.Services;
using SECO_Weather.Services.Implementation;

namespace SECO_Weather.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string city)
        {
            IWeather weather = new WeatherImpl();

            DTO weatherDetail = weather.WeatherDetail(city);
            Main main = new Main();

            ViewData["Temperature"] = weatherDetail.main.temp;
            ViewData["Humidity"] = weatherDetail.main.humidity;
            ViewData["WindSpeed"] = weatherDetail.wind.speed;
            ViewData["WindDirection"] = weatherDetail.wind.deg;
            ViewData["Description"] = weatherDetail.weather[0].description;
            ViewData["Icon"] = "http://openweathermap.org/img/wn/"+ weatherDetail.weather[0].icon +"@2x.png" ;

            return View();
        }
    }
}
