using configuration;
using configuration.configs;

namespace facades
{
  public static class StaticsFacade
  {
    public static Debug StaticDebug => StaticData.Debug;
    public static Configuration StaticConfiguration => StaticData.Configuration;
    public static Paths StaticPaths => StaticData.Paths;
  }
}