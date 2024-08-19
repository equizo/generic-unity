using System;
using System.Collections.Generic;
using infrastructure.interfaces;
using static facades.StaticsFacade;

namespace infrastructure.state_machines
{
  public class StateMachine : IStateMachine
  {
    protected Dictionary<Type, IExitState> _states;
    protected IExitState _activeState;
    public IExitState ActiveState => _activeState;

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      DebugState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payload) where TState : class, IPayloadState<TPayLoad>
    {
      TState state = ChangeState<TState>();
      DebugState<TState>();
      state.Enter(payload);
    }

    public virtual void UpdateActiveState(float deltaTime)
    {
    }

    private void DebugState<TState>() where TState : class =>
      StaticDebug.StateMachine.Print<TState>(string.Empty, "enter");

    private TState ChangeState<TState>() where TState : class, IExitState
    {
      _activeState?.Exit();
      TState state = GetState<TState>();
      _activeState = state;
      return state;
    }

    protected TState GetState<TState>() where TState : class, IExitState =>
      _states[typeof(TState)] as TState;
  }
}