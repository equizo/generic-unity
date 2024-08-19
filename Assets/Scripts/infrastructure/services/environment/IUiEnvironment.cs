using configuration.wrappers;
using ui_navigation;
using UnityEngine;

namespace infrastructure.services.environment
{
  public interface IUiEnvironment
  {
    void      InitNavigation(ActionsPair actionPair);
    Transform ScreensHolder { get; }
    void      SetScreenInfo(ScreenWrapper screenWrapper);
  }
}