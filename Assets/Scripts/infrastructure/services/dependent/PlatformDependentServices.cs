using device;
using extensions;
using infrastructure.services.ui.transitions;
using static facades.StaticsFacade;

namespace infrastructure.services.dependent
{
  public static class PlatformDependentServices
  {
    private static string _platformDirectoryPath;

    public static IScreenTransition ScreenTransition { get; private set; }

    public static void Init(PlatformTypes platformType)
    {
      _platformDirectoryPath = PlatformDirectory(platformType);
      SetScreensTransitionService();
    }

    private static string PlatformDirectory(PlatformTypes platformType) =>
      platformType switch {
        PlatformTypes.Desktop => StaticPaths.DesktopDirectory,
        PlatformTypes.Tablet => StaticPaths.MobileDirectory,
        PlatformTypes.Phone => StaticPaths.MobileDirectory,
        _ => StaticPaths.DesktopDirectory
      };

    public static string StaticDataPath {
      get {
      #if UNITY_EDITOR
        return StaticDataPaths.EditorPath;
      #endif
        return StaticDataPaths.BuildPath;
      }
    }

    public static string PrefabPath(string path) =>
      StaticPaths.Prefab(_platformDirectoryPath.Combine(path));

    private static void SetScreensTransitionService()
    {
    #if UNITY_STANDALONE
      ScreenTransition = DesktopScreenTransition;
    #else
      ScreenTransition = MobileScreenTransition;
    #endif
    }

    private static IScreenTransition DesktopScreenTransition =>
      new VerticalZoomAlphaScreenTransition(); // Can be replaced with ToggleScreenTransition or any other for development purposes
    
    private static IScreenTransition MobileScreenTransition =>
      new HorizontalZoomAlphaScreenTransition();
  }
}