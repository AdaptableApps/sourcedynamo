using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using weatherit.client.ViewModels;
  
namespace weatherit.blazorwasm.Pages;

public partial class WeatherForecastBase: ComponentBase
{
  #region Fields
  
  protected WeatherForecastMultipleViewModel _MultipleViewModel = new();

  #endregion Fields

  #region Methods
    
  protected override async Task OnInitializedAsync()
  {
    try
    {
      await _MultipleViewModel.InitAsync();
    }
    catch (Exception exception)
    {
      Console.WriteLine("Error : " + exception.Message);
    }
  }

  #endregion Methods
}
