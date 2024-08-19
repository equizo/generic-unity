using infrastructure.gameplay.equipment;
using infrastructure.interfaces;
using infrastructure.services.configs;
using infrastructure.services.environment;
using infrastructure.services.random;
using infrastructure.services.ui;
using infrastructure.state_machines;
using ui_navigation;

namespace infrastructure.states.implementations
{
  public class MenuNavigationState : IState
  {
    private readonly IEnvironmentGameObjectsCarrierService _environmentGameObjectsCarrierService;
    private readonly IMenuNavigationReactionService _menuNavigationReactionService;
    private readonly IScreenEntityProvider _screenEntityProvider;
    private readonly IConfigsProviderService _configsProviderService;
    private readonly IRandomService _randomService;
    private readonly IEquipmentRendererService _equipmentRendererService;

    public MenuNavigationState(IEnvironmentGameObjectsCarrierService environmentGameObjectsCarrierService,
                               IMenuNavigationReactionService menuNavigationReactionService,
                               IScreenEntityProvider screenEntityProvider,
                               IConfigsProviderService configsProviderService,
                               IRandomService randomService,
                               IEquipmentRendererService equipmentRendererService)
    {
      _equipmentRendererService = equipmentRendererService;
      _randomService = randomService;
      _configsProviderService = configsProviderService;
      _screenEntityProvider = screenEntityProvider;
      _environmentGameObjectsCarrierService = environmentGameObjectsCarrierService;
      _menuNavigationReactionService = menuNavigationReactionService;
    }

    public void Enter() =>
      CreateMenuNavigation();

    private void CreateMenuNavigation()
    {
      var menuNavigationStateMachine =
        new MenuNavigationStateMachine(_configsProviderService, _randomService, _equipmentRendererService);
      _menuNavigationReactionService.SetStateMachine(menuNavigationStateMachine);
      var menuNavigationActionsProvider =
        new MenuNavigationActions(_environmentGameObjectsCarrierService, _menuNavigationReactionService,
          _screenEntityProvider);

      menuNavigationActionsProvider.InitStartScreen();
    }

    public void Exit()
    {
    }
  }
}