﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using weatherit.core;
using weatherit.core.Models;

namespace weatherit.blazorwasm.Pages;

public partial class FetchData
{
  private WeatherForecast[]? _weatherForecasts;

  protected override async Task OnInitializedAsync()
  {
    try
    {
      var httpClient = new HttpClient() {BaseAddress = new Uri(CoreStatic.ServerBaseUrl)};
      // httpClient.DefaultRequestHeaders.Clear();
      httpClient.DefaultRequestHeaders.Add("Origin", CoreStatic.ClientBaseUrl);
      httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);

      var httpRequestUri = new Uri(Path.Combine(CoreStatic.ServerBaseUrl, "WeatherForecast"));
      Console.WriteLine(httpRequestUri.ToString());

      var httpRequest = new HttpRequestMessage(HttpMethod.Get, httpRequestUri);
      // httpRequest.Headers.Clear();
      httpRequest.SetBrowserRequestMode(BrowserRequestMode.Cors);
      httpRequest.Headers.Add("Origin", CoreStatic.ClientBaseUrl);
      httpRequest.Headers.Add("Access-Control-Allow-Origin", CoreStatic.ClientBaseUrl);

      var httpResponseMessage = await httpClient.SendAsync(httpRequest);

      var responseSuccessful = httpResponseMessage.IsSuccessStatusCode;

      if (responseSuccessful)
      {
        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

        // var getWeatherForecastResponse = JsonSerializer.Deserialize<GetWeatherForecastResponse>(responseString, JsonSerializerOptions.Default);
        var weatherForecasts = JsonSerializer.Deserialize<WeatherForecast[]>(responseString, JsonSerializerOptions.Default);

        if (weatherForecasts != null)
        {
          // this._weatherForecasts = getWeatherForecastResponse.WeatherForecasts;
          this._weatherForecasts = weatherForecasts;
        }

        StateHasChanged();
      } //if
      else
      {
        Console.WriteLine("Http Error " + httpResponseMessage.StatusCode + ", Reason: " + httpResponseMessage.ReasonPhrase);
      } //else
    } //try
    catch (Exception exception)
    {
      Console.WriteLine("Error : " + exception.Message);
    }
  }
}
