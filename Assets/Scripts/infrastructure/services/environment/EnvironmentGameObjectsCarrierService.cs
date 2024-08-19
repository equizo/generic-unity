namespace infrastructure.services.environment
{
  public class EnvironmentGameObjectsCarrierService : IEnvironmentGameObjectsCarrierService
  {
    public IUiEnvironment UiEnvironment { get; private set; }

    public void SetUiEnvironment(IUiEnvironment uiEnvironment) =>
      UiEnvironment = uiEnvironment;
  }
}