using System;
using System.Collections.Generic;
using Cinemachine;
using infrastructure.interfaces;
using infrastructure.services.dependent;
using infrastructure.services.environment;
using infrastructure.services.factory;
using infrastructure.services.ui;
using infrastructure.state_machines;
using infrastructure.states.implementations.menu_navigation;
using static facades.StaticsFacade;

namespace infrastructure.states.implementations
{
  public class EnvironmentState : IState
  {
    private readonly IGameObjectsFactoryService _gameObjectsFactoryService;
    private readonly GameStateMachine _gameStateMachine;
    private readonly IEnvironmentGameObjectsCarrierService _environmentGameObjectsCarrierService;
    private readonly IVirtualCamerasHandlerService _virtualCamerasHandlerService;
    private readonly IScreenEntityProvider _screenEntityProvider;

    public EnvironmentState(GameStateMachine gameStateMachine,
                            IGameObjectsFactoryService gameObjectsFactoryService,
                            IEnvironmentGameObjectsCarrierService environmentGameObjectsCarrierService,
                            IVirtualCamerasHandlerService virtualCamerasHandlerService,
                            IScreenEntityProvider screenEntityProvider)
    {
      _gameStateMachine = gameStateMachine;
      _gameObjectsFactoryService = gameObjectsFactoryService;
      _environmentGameObjectsCarrierService = environmentGameObjectsCarrierService;
      _virtualCamerasHandlerService = virtualCamerasHandlerService;
      _screenEntityProvider = screenEntityProvider;
    }

    public void Enter()
    {
      _gameObjectsFactoryService.Create(StaticPaths.Prefab(StaticPaths.BaseCamera));
      var sceneEnvironment = CreateEnvironments();
      InitVirtualCamerasHandlerService(sceneEnvironment.sceneEnvironment);
      _screenEntityProvider.LoadAndInitScreens(sceneEnvironment.uiEnvironment);
      _gameStateMachine.Enter<MenuNavigationState>();
    }

    private (ISceneEnvironment sceneEnvironment, IUiEnvironment uiEnvironment) CreateEnvironments()
    {
      var sceneEnvironment =
        _gameObjectsFactoryService.Create<ISceneEnvironment>(PlatformDependentServices.PrefabPath(StaticPaths.SceneEnvironment));

      var uiEnvironment =
        _gameObjectsFactoryService.Create<IUiEnvironment>(PlatformDependentServices.PrefabPath(StaticPaths.UiEnvironment));
      _environmentGameObjectsCarrierService.SetUiEnvironment(uiEnvironment);

      return (sceneEnvironment, uiEnvironment);
    }

    private void InitVirtualCamerasHandlerService(ISceneEnvironment sceneEnvironment) =>
      _virtualCamerasHandlerService.AddVirtualCameras(
        new Dictionary<Type, CinemachineVirtualCamera> {
          {typeof(EquipmentState), sceneEnvironment.EquipmentVirtualCamera},
          {typeof(BoxingState), sceneEnvironment.BoxingVirtualCamera},
          {typeof(AbilitiesState), sceneEnvironment.AbilitiesVirtualCamera}
        }, sceneEnvironment.EquipmentVirtualCamera);

    public void Exit()
    {
    }
  }
}