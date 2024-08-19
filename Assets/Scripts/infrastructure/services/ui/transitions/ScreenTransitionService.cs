using System.Collections.Generic;
using ui;

namespace infrastructure.services.ui.transitions
{
  public class ScreenTransitionService : IScreenTransitionService
  {
    private readonly Queue<ScreenTransitionRequest> _transitionQueue = new();
    private readonly IScreenTransition _screenTransition;
    private bool _isTransitioning;

    public ScreenTransitionService(IScreenTransition screenTransition) =>
      _screenTransition = screenTransition;

    public void RequestTransition(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen)
    {
      _transitionQueue.Enqueue(new ScreenTransitionRequest(activeUiScreen, newUiScreen));

      if (!_isTransitioning) {
        ProcessQueue();
      }
    }

    private void ProcessQueue()
    {
      if (_transitionQueue.Count > 0) {
        var nextRequest = _transitionQueue.Dequeue();
        _isTransitioning = true;
        _screenTransition.Animate(nextRequest.ActiveUiScreen, nextRequest.NewUiScreen, ProcessQueue);
      }
      else {
        _isTransitioning = false;
      }
    }
  }
}