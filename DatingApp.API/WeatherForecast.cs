using System;

namespace DatingApp.API
{
    public class WeatherForecast
    {
        private DateTime Date { get; set; }

        private int TemperatureC { get; set; }

        private int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        private string Summary { get; set; }
    }
}
