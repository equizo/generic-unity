using System;
using System.Collections.Generic;
using configuration.wrappers;
using infrastructure.services.configs;
using infrastructure.services.dependent;
using infrastructure.services.environment;
using infrastructure.services.factory;
using infrastructure.states.implementations.menu_navigation;
using ui;
using UnityEngine;
using static facades.StaticsFacade;

namespace infrastructure.services.ui
{
  public class ScreenEntityProvider : IScreenEntityProvider
  {
    private readonly IGameObjectsFactoryService _gameObjectsFactoryService;

    private readonly Dictionary<Type, ScreenWrapper> _screenDataByState = new();
    private readonly Dictionary<Type, IUiScreenContent> _screenContentByState = new();
    private readonly IConfigsProviderService _configsProviderService;

    private static readonly Dictionary<ScreenStateType, Type> StateTypeMappings = new() {
      {ScreenStateType.Equipment, typeof(EquipmentState)},
      {ScreenStateType.Boxing, typeof(BoxingState)},
      {ScreenStateType.Abilities, typeof(AbilitiesState)}
    };

    public ScreenEntityProvider(IGameObjectsFactoryService gameObjectsFactoryService, 
                                IConfigsProviderService configsProviderService)
    {
      _configsProviderService = configsProviderService;
      _gameObjectsFactoryService = gameObjectsFactoryService;
    }

    public void LoadAndInitScreens(IUiEnvironment uiEnvironment)
    {
      var uiScreenWrappers = _configsProviderService.Get<ScreenWrapperCollection>(StaticConfiguration.ConfigurationFilesList.UiScreens);
      var screens = uiScreenWrappers.screens;
      for (var i = 0; i < screens.Count; i++) {
        var screen = screens[i];
        var screenContent = _gameObjectsFactoryService.Create<IUiScreenContent>(StaticPaths.Prefab(StaticPaths.Screen),
          uiEnvironment.ScreensHolder);

        var stateScreenContent = _gameObjectsFactoryService.Create(PlatformDependentServices.PrefabPath(screen.Prefab), screenContent.Content.transform);
        screenContent.ScreenSpecificContent = stateScreenContent.transform;

        var screenStateType = (ScreenStateType) screen.StateType;
        if (StateTypeMappings.TryGetValue(screenStateType, out Type state)) {
          _screenDataByState[state] = screen;
          _screenContentByState[state] = screenContent;
        }
        else {
          Debug.LogError($"{screenStateType} not found in {nameof(StateTypeMappings)}");
        }
      }
    }

    public ScreenWrapper GetScreenData<T>()
    {
      if (_screenDataByState.TryGetValue(typeof(T), out var screenData)) {
        return screenData;
      }

      Debug.LogError($"{typeof(ScreenWrapper)} not found for {typeof(T)}");
      return null;
    }
    
    public IUiScreenContent GetScreenContent<T>()
    {
      if (_screenContentByState.TryGetValue(typeof(T), out var screenContent)) {
        return screenContent;
      }

      Debug.LogError($"{typeof(IUiScreenContent)} not found for {typeof(T)}");
      return null;
    }
  }
}