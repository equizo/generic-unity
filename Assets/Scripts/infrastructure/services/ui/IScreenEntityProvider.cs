using configuration.wrappers;
using infrastructure.services.environment;
using ui;

namespace infrastructure.services.ui
{
  public interface IScreenEntityProvider : IService
  {
    void           LoadAndInitScreens(IUiEnvironment uiEnvironment);
    ScreenWrapper  GetScreenData<T>();
    IUiScreenContent GetScreenContent<T>();
  }
}