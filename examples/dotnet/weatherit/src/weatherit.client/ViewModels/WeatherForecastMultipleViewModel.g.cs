/*
 *
 * Generated Class - Do not Modify!
 *
 */

using System.Threading.Tasks;
using weatherit.core.Models;

namespace weatherit.client.ViewModels;

public partial class WeatherForecastMultipleViewModel
{
  #region Fields
  
  private WeatherForecast[] _ModelArray;

  #endregion Fields

  #region Properties

  public WeatherForecast[] ModelArray => _ModelArray;

  #endregion Properties
  
  #region Constructors

  #endregion Constructors

  #region Methods

  public async Task InitAsync()
  {
    _ModelArray = await ClientServiceHelperStatic.GetMultiple<WeatherForecast>();
  }
 
  #endregion Methods
}
