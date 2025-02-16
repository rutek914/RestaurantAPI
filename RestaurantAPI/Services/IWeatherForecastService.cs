using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Services
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get();
        public IEnumerable<WeatherForecast> Get(int resultNr, int minTemp, int maxTemp);
    }
}
