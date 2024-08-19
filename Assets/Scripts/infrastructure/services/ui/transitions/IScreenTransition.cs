using System;
using ui;

namespace infrastructure.services.ui.transitions
{
  public interface IScreenTransition
  {
    void Animate(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen, Action onFinish);
  }
}