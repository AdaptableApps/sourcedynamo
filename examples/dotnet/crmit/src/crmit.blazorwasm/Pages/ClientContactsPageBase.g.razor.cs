using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using crmit.client.ViewModels;
  
namespace crmit.blazorwasm.Pages;

public partial class ClientContactsPageBase : ComponentBase
{
  #region Fields
  
  protected ClientContactMultipleViewModel _MultipleViewModel = new();

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
