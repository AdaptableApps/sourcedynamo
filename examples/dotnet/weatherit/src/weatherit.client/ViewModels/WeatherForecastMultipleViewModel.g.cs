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
  
  private WeatherForecast[] _WeatherForecastArray;

  #endregion Fields

  #region Properties

  public WeatherForecast[] ModelArray => _WeatherForecastArray;

  #endregion Properties
  
  #region Constructors

  #endregion Constructors

  #region Methods

  public async Task InitAsync()
  {
    WeatherForecast[] modelArray = await ClientServiceHelperStatic.GetMultiple<WeatherForecast>();
    _WeatherForecastArray = modelArray;
  }
 
  #endregion Methods
}
