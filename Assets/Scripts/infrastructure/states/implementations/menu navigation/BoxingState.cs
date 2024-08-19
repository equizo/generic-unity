using infrastructure.interfaces;
using static facades.StaticsFacade;

namespace infrastructure.states.implementations.menu_navigation
{
  public class BoxingState : IState
  {
    public void Enter() =>
      StaticDebug.Network.Print<BoxingState>($"API request sent");

    public void Exit()
    {
    }
  }
}