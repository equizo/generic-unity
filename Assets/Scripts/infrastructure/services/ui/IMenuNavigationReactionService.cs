using infrastructure.interfaces;

namespace infrastructure.services.ui
{
  public interface IMenuNavigationReactionService : IService
  {
    void Update<TState>() where TState : class, IState;
    void SetStateMachine(IStateMachine stateMachine);
  }
}