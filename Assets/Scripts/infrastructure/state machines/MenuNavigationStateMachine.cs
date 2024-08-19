using System;
using System.Collections.Generic;
using infrastructure.gameplay.equipment;
using infrastructure.interfaces;
using infrastructure.services.configs;
using infrastructure.services.random;
using infrastructure.states.implementations.menu_navigation;

namespace infrastructure.state_machines
{
  public class MenuNavigationStateMachine : StateMachine
  {
    public MenuNavigationStateMachine(IConfigsProviderService configsProviderService,
                                      IRandomService randomService,
                                      IEquipmentRendererService equipmentRendererService) =>
      _states = new Dictionary<Type, IExitState> {
        {typeof(EquipmentState), new EquipmentState(configsProviderService, randomService, equipmentRendererService)},
        {typeof(BoxingState), new BoxingState()},
        {typeof(AbilitiesState), new AbilitiesState()},
      };
  }
}