using infrastructure.services;
using infrastructure.state_machines;

namespace infrastructure
{
  public class Game
  {
    public IStateMachine StateMachine { get; }

    public Game() =>
      StateMachine = new GameStateMachine(AllServices.Container);

    public void Update(float deltaTime) =>
      StateMachine.UpdateActiveState(deltaTime);
  }
}