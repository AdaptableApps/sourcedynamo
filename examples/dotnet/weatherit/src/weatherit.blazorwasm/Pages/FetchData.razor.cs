﻿// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Net;
// using System.Net.Http;
// using System.Net.Http.Json;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Components.WebAssembly.Http;
// using weatherit.client.ViewModels;
// using weatherit.core;
// using weatherit.core.Models;
//
// namespace weatherit.blazorwasm.Pages;
//
// public partial class FetchData
// {
//   private WeatherForecastMultipleViewModel _MultipleViewModel = new();
//
//   protected override async Task OnInitializedAsync()
//   {
//     try
//     {
//       await _MultipleViewModel.InitAsync();
//     } //try
//     catch (Exception exception)
//     {
//       Console.WriteLine("Error : " + exception.Message);
//     }
//   }
// }
