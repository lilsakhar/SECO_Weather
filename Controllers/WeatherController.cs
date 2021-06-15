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

            SelectList selectList = new SelectList(lstCity,  "Warsaw");

            ViewData["City"] = selectList;

            string city = selectList.SelectedValue.ToString();

            //Details
            //if (!string.IsNullOrWhiteSpace(city))
            //    GetWeather(city);

            DTO weatherDetail = GetWeather(city);
            return View(weatherDetail);
        }

        public IActionResult ShowWeather(string city)
        {
            DTO weatherDetail = GetWeather(city);

            return PartialView("ShowWeather", weatherDetail);
        }

        public DTO GetWeather(string city)
        {
            IWeather weather = new WeatherImpl();

            DTO weatherDetail = weather.WeatherDetail(city);

            weatherDetail.weather[0].icon =
                "http://openweathermap.org/img/wn/" + weatherDetail.weather[0].icon + "@2x.png";

            return weatherDetail;
            //ViewData["Temperature"] = weatherDetail.main.temp;
            //ViewData["Humidity"] = weatherDetail.main.humidity;
            //ViewData["WindSpeed"] = weatherDetail.wind.speed;
            //ViewData["WindDirection"] = weatherDetail.wind.deg;
            //ViewData["Description"] = weatherDetail.weather[0].description;
            //ViewData["Icon"] = "http://openweathermap.org/img/wn/" + weatherDetail.weather[0].icon + "@2x.png";
        }
        
    }
}
