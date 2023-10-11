/*
 *
 * Generated Class - Do not Modify!
 *
 */

using System.Threading.Tasks;
using crmit.core.Models;

namespace crmit.client.ViewModels;

public partial class ClientContactMultipleViewModel
{
  #region Fields
  
  private ClientContact[] _ModelArray;

  #endregion Fields

  #region Properties

  public ClientContact[] ModelArray => _ModelArray;

  #endregion Properties
  
  #region Constructors

  #endregion Constructors

  #region Methods

  public async Task InitAsync()
  {
    _ModelArray = await ClientServiceHelperStatic.GetMultiple<ClientContact>(nameof(ClientContact));
  }
 
  #endregion Methods
}
