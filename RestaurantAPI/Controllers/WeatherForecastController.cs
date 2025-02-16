using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
       return _weatherForecastService.Get();
    }

    [HttpPost]
    [Route("generate")]
    public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int resultNr, [FromBody] TemperatureRequest request)
    {
        if (resultNr > 0 && request.MinTemp < request.MaxTemp)
        {
            return Ok( _weatherForecastService.Get(resultNr, request.MinTemp, request.MaxTemp));
        }
        return BadRequest();
    }
}
