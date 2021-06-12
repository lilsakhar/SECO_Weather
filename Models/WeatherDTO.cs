using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SECO_Weather.Models
{
    public class WeatherDTO
    {
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Weather weather { get; set; }

    }
}
