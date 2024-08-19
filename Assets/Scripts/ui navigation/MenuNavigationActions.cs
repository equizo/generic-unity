using System;
using System.Collections.Generic;
using infrastructure.interfaces;
using infrastructure.services.environment;
using infrastructure.services.ui;
using infrastructure.states.implementations.menu_navigation;

namespace ui_navigation
{
  public class MenuNavigationActions
  {
    private readonly IEnvironmentGameObjectsCarrierService _environmentGameObjectsCarrierService;
    private readonly IMenuNavigationReactionService _menuNavigationReactionService;
    private readonly IScreenEntityProvider _screenEntityProvider;

    public Dictionary<Type, ActionsPair> NavigationActionsByState { get; }

    public MenuNavigationActions(IEnvironmentGameObjectsCarrierService environmentGameObjectsCarrierService,
                                 IMenuNavigationReactionService menuNavigationReactionService,
                                 IScreenEntityProvider screenEntityProvider)
    {
      _screenEntityProvider = screenEntityProvider;
      _environmentGameObjectsCarrierService = environmentGameObjectsCarrierService;
      _menuNavigationReactionService = menuNavigationReactionService;
      NavigationActionsByState = InitNavigationActionsByState();
    }

    public void InitStartScreen()
    {
      NavigateTo<EquipmentState>();
      _screenEntityProvider.GetScreenContent<EquipmentState>().Enable();
    }

    private Dictionary<Type, ActionsPair> InitNavigationActionsByState() =>
      new() {
        {typeof(EquipmentState), CreateActionsPair(null, NavigateTo<BoxingState>)},
        {typeof(BoxingState), CreateActionsPair(NavigateTo<EquipmentState>, NavigateTo<AbilitiesState>)},
        {typeof(AbilitiesState), CreateActionsPair(NavigateTo<BoxingState>, null)}
      };

    private ActionsPair CreateActionsPair(Action onBack, Action onForward) =>
      new() {OnBack = onBack, OnForward = onForward};

    private void NavigateTo<TState>() where TState : class, IState
    {
      _menuNavigationReactionService.Update<TState>();
      _environmentGameObjectsCarrierService.UiEnvironment.InitNavigation(NavigationActionsByState[typeof(TState)]);
    }
  }
}