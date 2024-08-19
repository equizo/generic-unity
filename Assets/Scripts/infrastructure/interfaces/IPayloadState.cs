namespace infrastructure.interfaces
{
  public interface IPayloadState<TPayload> : IExitState
  {
    void Enter(TPayload payload);
  }
}