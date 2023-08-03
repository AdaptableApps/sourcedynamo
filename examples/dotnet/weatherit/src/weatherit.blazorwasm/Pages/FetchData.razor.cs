namespace DefaultNamespace;

public partial class FetchData
{
  private WeatherForecast[]? forecasts;

  protected override async Task OnInitializedAsync()
  {
    forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("http://localhost:5283/WeatherForecast");
  }
}