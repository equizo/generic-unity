using infrastructure.interfaces;
using infrastructure.services.environment;

namespace infrastructure.services.ui
{
  public class MenuNavigationReactionService : IMenuNavigationReactionService
  {
    private readonly IVirtualCamerasHandlerService _virtualCamerasHandlerService;
    private readonly IActiveScreenHandler _activeScreenHandler;
    private IStateMachine _stateMachine;

    public MenuNavigationReactionService(IActiveScreenHandler activeScreenHandler,
                                         IVirtualCamerasHandlerService virtualCamerasHandlerService)
    {
      _activeScreenHandler = activeScreenHandler;
      _virtualCamerasHandlerService = virtualCamerasHandlerService;
    }

    public void SetStateMachine(IStateMachine stateMachine) =>
      _stateMachine = stateMachine;

    public void Update<TState>() where TState : class, IState
    {
      _activeScreenHandler.Set<TState>();
      _virtualCamerasHandlerService.SetActive<TState>();
      _stateMachine.Enter<TState>();
    }
  }
}