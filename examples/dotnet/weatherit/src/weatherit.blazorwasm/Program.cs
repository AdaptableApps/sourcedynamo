using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using weatherit.blazorwasm;
using weatherit.core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

CoreStatic.ServerBaseUrl = "https://localhost:7299";
CoreStatic.ClientBaseUrl = builder.HostEnvironment.BaseAddress;
if (CoreStatic.ClientBaseUrl.EndsWith("/"))
{
  CoreStatic.ClientBaseUrl = CoreStatic.ClientBaseUrl.Substring(0, CoreStatic.ClientBaseUrl.Length - 1);
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(CoreStatic.ClientBaseUrl) });

await builder.Build().RunAsync();
