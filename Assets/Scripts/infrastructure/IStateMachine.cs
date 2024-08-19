using infrastructure.interfaces;

namespace infrastructure
{
  public interface IStateMachine
  {
    void       Enter<TState>() where TState : class, IState;
    void       Enter<TState, TPayLoad>(TPayLoad payload) where TState : class, IPayloadState<TPayLoad>;
    void       UpdateActiveState(float deltaTime);
    IExitState ActiveState { get; }
  }
}