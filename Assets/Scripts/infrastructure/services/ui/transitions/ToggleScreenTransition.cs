using System;
using ui;

namespace infrastructure.services.ui.transitions
{
  public class ToggleScreenTransition : IScreenTransition
  {
    public void Animate(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen, Action onFinish)
    {
      activeUiScreen.Disable();
      newUiScreen.Enable();
      onFinish.Invoke();
    }
  }
}