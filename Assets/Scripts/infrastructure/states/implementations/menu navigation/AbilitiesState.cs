using infrastructure.interfaces;
using static facades.StaticsFacade;

namespace infrastructure.states.implementations.menu_navigation
{
  public class AbilitiesState : IState
  {
    public void Enter() =>
      StaticDebug.Purchase.Print<AbilitiesState>("Ability purchased");

    public void Exit()
    {
    }
  }
}