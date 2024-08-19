using ui;

namespace infrastructure.services.ui.transitions
{
  public class ScreenTransitionRequest
  {
    public IUiScreenContent ActiveUiScreen { get; }
    public IUiScreenContent NewUiScreen    { get; }

    public ScreenTransitionRequest(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen)
    {
      ActiveUiScreen = activeUiScreen;
      NewUiScreen = newUiScreen;
    }
  }
}