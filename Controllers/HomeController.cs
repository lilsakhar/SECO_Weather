using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SECO_Weather.Models;
using SECO_Weather.Services;
using SECO_Weather.Services.Implementation;

namespace SECO_Weather.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Weather(string city)
        {
            IWeather weather = new WeatherImpl();
            
            WeatherDTO weatherDetail = weather.WeatherDetail(city);

            ViewData["Temperature"] = weatherDetail.main.temp;
            ViewData["Humidity"] = weatherDetail.main.humidity;
            ViewData["WindSpeed"] = weatherDetail.wind.windSpeed;
            ViewData["WindDirection"] = weatherDetail.wind.windDeg;
            ViewData["Description"] = weatherDetail.weather.description;
            ViewData["Icon"] = weatherDetail.weather.icon;

            return View();
        }


    }
}
