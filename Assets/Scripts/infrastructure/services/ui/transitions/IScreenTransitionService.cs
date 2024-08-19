using ui;

namespace infrastructure.services.ui.transitions
{
  public interface IScreenTransitionService : IService
  {
    void RequestTransition(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen);
  }
}