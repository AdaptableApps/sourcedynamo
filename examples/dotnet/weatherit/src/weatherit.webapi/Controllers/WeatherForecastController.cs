using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using weatherit.core.Models;

namespace weatherit.webapi.Controllers;

[Route("[controller]")]
public class WeatherForecastController
{
  #region Fields
  
  private static readonly string[] Summaries = new[]
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  #endregion Fields

  #region Methods

  [HttpGet(Name = "GetWeatherForecast")]
  public string Get()
  {
    var weatherForecastsArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToArray();
    
    // var getWeatherForecastResponse = new GetWeatherForecastResponse()
    // {
    //   WeatherForecasts = weatherForecastsArray
    // };

     var getWeatherForecastResponseString = JsonSerializer.Serialize<WeatherForecast[]>(weatherForecastsArray, JsonSerializerOptions.Default);

     return getWeatherForecastResponseString;
  }

  #endregion Methods
}
