namespace weatherit.core.Models;

public partial class WeatherForecast
{
  public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}
