using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using weatherit.core;
using weatherit.core.Models;

namespace weatherit.client;

public static class ClientServiceHelperStatic
{
  #region Methods
  
  public static async Task<T[]?> GetMultiple<T>()
  {
    T[]? results = null;
    
    try
    {
      using var httpClient = new HttpClient();
      httpClient.BaseAddress = new Uri(CoreStatic.ServerBaseUrl);
      // httpClient.DefaultRequestHeaders.Clear();
      httpClient.DefaultRequestHeaders.Add("Origin", CoreStatic.ClientBaseUrl);
      httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);

      var httpRequestUri = new Uri(Path.Combine(CoreStatic.ServerBaseUrl, "WeatherForecast"));
      Console.WriteLine(httpRequestUri.ToString());

      var httpRequest = new HttpRequestMessage(HttpMethod.Get, httpRequestUri);
      // httpRequest.Headers.Clear();
      // httpRequest.SetBrowserRequestMode(BrowserRequestMode.Cors);
      httpRequest.Headers.Add("Origin", CoreStatic.ClientBaseUrl);
      httpRequest.Headers.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);

      var httpResponseMessage = await httpClient.SendAsync(httpRequest);

      var responseSuccessful = httpResponseMessage.IsSuccessStatusCode;

      if (responseSuccessful)
      {
        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
          
        results = JsonSerializer.Deserialize<T[]>(responseString, JsonSerializerOptions.Default);
      } //if
      else
      {
        Console.WriteLine("Http Error " + httpResponseMessage.StatusCode + ", Reason: " + httpResponseMessage.ReasonPhrase);
      } //else
    } //try
    catch (Exception exception)
    {
      Console.WriteLine("Error : " + exception.Message);
      throw;
    }

    return results;
  }
  
  #endregion Methods
}
