using infrastructure.services.environment;
using infrastructure.services.ui.transitions;
using ui;

namespace infrastructure.services.ui
{
  public class ActiveScreenHandler : IActiveScreenHandler 
  {
    private readonly IScreenEntityProvider _screenEntityProvider;
    private readonly IEnvironmentGameObjectsCarrierService _environmentGameObjectsCarrierService;
    private readonly IScreenTransitionService _screenTransitionService;

    private IUiScreenContent _activeUiScreen;
    
    public ActiveScreenHandler(IScreenEntityProvider screenEntityProvider,
                               IEnvironmentGameObjectsCarrierService environmentGameObjectsCarrierService,
                               IScreenTransitionService screenTransitionService)
    {
      _screenTransitionService = screenTransitionService;
      _screenEntityProvider = screenEntityProvider;
      _environmentGameObjectsCarrierService = environmentGameObjectsCarrierService;
    }

    public void Set<T>()
    {
      var screenWrapper = _screenEntityProvider.GetScreenData<T>();
      _environmentGameObjectsCarrierService.UiEnvironment.SetScreenInfo(screenWrapper);
      AnimateTransition<T>();
    }

    private void AnimateTransition<T>()
    {
      var newScreen = _screenEntityProvider.GetScreenContent<T>();
      if (_activeUiScreen != null) {
        _screenTransitionService.RequestTransition(_activeUiScreen, newScreen);
      }

      _activeUiScreen = newScreen;
    }
  }
}