using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using weatherit.core.Models;

namespace weatherit.webapi.Controllers;

// [ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  private readonly ILogger<WeatherForecastController> _logger;

  public WeatherForecastController(ILogger<WeatherForecastController> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  public string Get()
  {
    var weatherForecastsArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToArray();
    
    var getWeatherForecastResponse = new GetWeatherForecastResponse()
    {
      WeatherForecasts = weatherForecastsArray
    };

     var getWeatherForecastResponseString = JsonSerializer.Serialize<GetWeatherForecastResponse>(getWeatherForecastResponse, JsonSerializerOptions.Default);

     return getWeatherForecastResponseString;
  }
}
