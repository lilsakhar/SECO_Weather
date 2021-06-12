using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SECO_Weather.Models;

namespace SECO_Weather.Services.Implementation
{
    public class WeatherImpl: IWeather
    {
        public WeatherDTO WeatherDetail(string City)
        {
            string appKeyID = "f406fea8c9c154ccb14e5fc53aa91bb7";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", City,
                appKeyID);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherDTO weatherInfo = System.Text.Json.JsonSerializer.Deserialize<WeatherDTO>(response);

            //WeatherDTO weatherInfo = JsonConvert.DeserializeObject<WeatherDTO>(response);

            return weatherInfo;
        }
    }
}
