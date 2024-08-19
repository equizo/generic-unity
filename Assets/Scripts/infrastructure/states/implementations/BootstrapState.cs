using infrastructure.gameplay.equipment;
using infrastructure.interfaces;
using infrastructure.services;
using infrastructure.services.assets;
using infrastructure.services.configs;
using infrastructure.services.dependent;
using infrastructure.services.environment;
using infrastructure.services.factory;
using infrastructure.services.random;
using infrastructure.services.serialization;
using infrastructure.services.ui;
using infrastructure.services.ui.transitions;
using infrastructure.state_machines;

namespace infrastructure.states.implementations
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, AllServices services)
    {
      _stateMachine = stateMachine;
      _services = services;
      RegisterServices();
    }

    private void RegisterServices()
    {
      _services.RegisterSingle<IAssetProvider>(new ResourceAssetProvider());
      _services.RegisterSingle<ICachedSpritesProviderService>(
        new CachedSpritesProviderService(_services.Single<IAssetProvider>()));
      _services.RegisterSingle<IGameObjectsFactoryService>(
        new GameObjectsFactoryService(_services.Single<IAssetProvider>()));
      _services.RegisterSingle<IEnvironmentGameObjectsCarrierService>(new EnvironmentGameObjectsCarrierService());
      _services.RegisterSingle<IVirtualCamerasHandlerService>(new VirtualCamerasHandlerService());
      _services.RegisterSingle<ISerializationService>(new UnityJsonSerializationService());
      _services.RegisterSingle<IConfigsProviderService>(new ConfigsProviderService(_services.Single<IAssetProvider>(),
        _services.Single<ISerializationService>()));
      _services.RegisterSingle<IScreenEntityProvider>(new ScreenEntityProvider(
        _services.Single<IGameObjectsFactoryService>(),
        _services.Single<IConfigsProviderService>()));
      _services.RegisterSingle<IScreenTransitionService>(
        new ScreenTransitionService(PlatformDependentServices.ScreenTransition));
      _services.RegisterSingle<IActiveScreenHandler>(new ActiveScreenHandler(_services.Single<IScreenEntityProvider>(),
        _services.Single<IEnvironmentGameObjectsCarrierService>(),
        _services.Single<IScreenTransitionService>()));
      _services.RegisterSingle<IMenuNavigationReactionService>(new MenuNavigationReactionService(
        _services.Single<IActiveScreenHandler>(),
        _services.Single<IVirtualCamerasHandlerService>()));
      _services.RegisterSingle<IRandomService>(new UnityRandomService());
      _services.RegisterSingle<IEquipmentRendererService>(new EquipmentRendererService(
        _services.Single<IScreenEntityProvider>(),
        _services.Single<IGameObjectsFactoryService>(), _services.Single<ICachedSpritesProviderService>()));
    }

    public void Enter() =>
      _stateMachine.Enter<EnvironmentState>();

    public void Exit()
    {
    }
  }
}