/*
 *
 * Generated Class - Do not Modify!
 *
 */

using System.Threading.Tasks;
using crmit.core.Models;

namespace crmit.client.ViewModels;

public partial class ClientMultipleViewModel
{
  #region Fields
  
  private Client[] _ModelArray;

  #endregion Fields

  #region Properties

  public Client[] ModelArray => _ModelArray;

  #endregion Properties
  
  #region Constructors

  #endregion Constructors

  #region Methods

  public async Task InitAsync()
  {
    _ModelArray = await ClientServiceHelperStatic.GetMultiple<Client>(nameof(Client));
  }
 
  #endregion Methods
}
