using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SECO_Weather.DataAccess;
using SECO_Weather.Models;
using SECO_Weather.Services;
using SECO_Weather.Services.Implementation;

namespace SECO_Weather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly CityDbContext _context;

        public WeatherController(CityDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<string> lstCity = new List<string>();

            lstCity = (from City in _context.City select City.name).ToList();

            var selectList = new SelectList(lstCity,  "name");

            ViewData["City"] = selectList;

            return View();
        }

        public IActionResult Details(string city)
        {
            IWeather weather = new WeatherImpl();

            DTO weatherDetail = weather.WeatherDetail(city);

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
