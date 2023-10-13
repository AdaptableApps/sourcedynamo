using Microsoft.AspNetCore.Components;

namespace crmit.blazorwasm.Shared;

public partial class NavMenu_g
{
  private bool collapseNavMenu = true;

  private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

  private void ToggleNavMenu()
  {
    collapseNavMenu = !collapseNavMenu;
  }
}
