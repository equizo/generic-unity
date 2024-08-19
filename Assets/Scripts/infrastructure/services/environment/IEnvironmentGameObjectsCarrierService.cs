namespace infrastructure.services.environment
{
  public interface IEnvironmentGameObjectsCarrierService : IService
  {
    IUiEnvironment UiEnvironment { get; }
    void           SetUiEnvironment(IUiEnvironment uiEnvironment);
  }
}