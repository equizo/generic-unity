using System;
using System.Collections.Generic;
using infrastructure.gameplay.equipment;
using infrastructure.interfaces;
using infrastructure.services;
using infrastructure.services.configs;
using infrastructure.services.environment;
using infrastructure.services.factory;
using infrastructure.services.random;
using infrastructure.services.ui;
using infrastructure.states.implementations;

namespace infrastructure.state_machines
{
  public class GameStateMachine : StateMachine
  {
    public GameStateMachine(AllServices services) =>
      _states = new Dictionary<Type, IExitState> {
        {
          typeof(BootstrapState), new BootstrapState(this, services)
        },
        {
          typeof(EnvironmentState), new EnvironmentState(this, services.Single<IGameObjectsFactoryService>(),
            services.Single<IEnvironmentGameObjectsCarrierService>(),
            services.Single<IVirtualCamerasHandlerService>(),
            services.Single<IScreenEntityProvider>())
        }, 
        {
          typeof(MenuNavigationState), new MenuNavigationState(
            services.Single<IEnvironmentGameObjectsCarrierService>(),
            services.Single<IMenuNavigationReactionService>(),
            services.Single<IScreenEntityProvider>(),
            services.Single<IConfigsProviderService>(),
            services.Single<IRandomService>(),
            services.Single<IEquipmentRendererService>())
        },
      };

    public override void UpdateActiveState(float deltaTime)
    {
    }
  }
}