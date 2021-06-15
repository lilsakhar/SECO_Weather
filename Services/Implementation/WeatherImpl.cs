using SECO_Weather.Models;
using System.IO;
using System.Net;

namespace SECO_Weather.Services.Implementation
{
    public class WeatherImpl: IWeather
    {
        public DTO WeatherDetail(string City)
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

            DTO weatherInfo = System.Text.Json.JsonSerializer.Deserialize<DTO>(response);

            return weatherInfo;
        }
    }
}
