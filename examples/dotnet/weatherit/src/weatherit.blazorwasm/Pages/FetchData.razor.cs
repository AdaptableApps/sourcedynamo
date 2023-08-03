using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using weatherit.core;
using weatherit.core.Models;

namespace weatherit.blazorwasm.Pages;

public partial class FetchData
{
  private WeatherForecast[]? forecasts;

  protected override async Task OnInitializedAsync()
  {
    try
    {
      var httpClient = new HttpClient() {BaseAddress = new Uri(CoreStatic.ServerBaseUrl)};
      httpClient.DefaultRequestHeaders.Add("Origin", CoreStatic.ClientBaseUrl);

      httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);
      
      var httpRequest = new HttpRequestMessage(HttpMethod.Get, "WeatherForecast");
      httpRequest.SetBrowserRequestMode(BrowserRequestMode.Cors);
      httpRequest.Headers.Add("Origin", CoreStatic.ClientBaseUrl);

      httpRequest.Headers.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);

      var httpResponseMessage = await httpClient.SendAsync(httpRequest);

      var responseSuccessful = httpResponseMessage.IsSuccessStatusCode;

      if (responseSuccessful)
      {
        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

        forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(responseString);
      } //if
      else
      {
        throw new Exception("Http Error " + httpResponseMessage.StatusCode + ", Reason: " + httpResponseMessage.ReasonPhrase);
      } //else
    } //try
    catch (Exception exception)
    {
      Console.WriteLine("Error : " + exception.Message);
    }
  }
}
