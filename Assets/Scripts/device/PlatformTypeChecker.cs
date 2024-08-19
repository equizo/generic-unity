using UnityEngine;

namespace device
{
  public static class PlatformTypeChecker
  {
    private const float TableDiagonalSizeThreshold = 7.5f;
    private const float TabletAspectRatioThreshold = 1.77f;

    private static PlatformTypes _platformType;

    public static PlatformTypes SetPlatformType() =>
      _platformType = GetPlatformType;

    private static PlatformTypes GetPlatformType {
      get {
      #if UNITY_STANDALONE
        return PlatformTypes.Desktop;
      #endif
        
      #if UNITY_IOS
        bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
        if (deviceIsIpad) {
          return PlatformTypes.Tablet;
        }

        bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
        if (deviceIsIphone) {
          return PlatformTypes.Phone;
        }
      #endif

        int width = Screen.width;
        int height = Screen.height;
        float aspectRatio = Mathf.Max((float) width, height) / Mathf.Min(width, height);
        bool isTablet = DeviceDiagonalSizeInInches > TableDiagonalSizeThreshold &&
                        aspectRatio                < TabletAspectRatioThreshold;
        return isTablet ? PlatformTypes.Tablet : PlatformTypes.Phone;
      }
    }

    private static float DeviceDiagonalSizeInInches {
      get {
        float screenWidth = Screen.width   / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(screenWidth * screenWidth + screenHeight * screenHeight);
        return diagonalInches;
      }
    }

  }
}