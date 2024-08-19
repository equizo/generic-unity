using System;
using System.Collections.Generic;
using configuration.configs;
using extensions;
using infrastructure;
using infrastructure.services.dependent;
using UnityEngine;

namespace configuration
{
  public static class StaticData
  {
    public static Debug Debug;
    public static Configuration Configuration;
    public static Paths Paths;

    private static Dictionary<Type, string> _pathByType;
    private static string _homePath;

    public static void Init()
    {
      InitPaths();
      Debug = Load<Debug>();
      Configuration = Load<Configuration>();
      Paths = Load<Paths>();
    }

    private static void InitPaths()
    {
      _homePath = StaticDataPaths.Home.Combine(PlatformDependentServices.StaticDataPath);
      _pathByType = new Dictionary<Type, string> {
        {typeof(Debug), HomePathTo(StaticDataPaths.DebugFile)},
        {typeof(Configuration), HomePathTo(StaticDataPaths.ConfigurationFile)},
        {typeof(Paths), HomePathTo(StaticDataPaths.PathsFile)},
      };
    }

    private static string HomePathTo(string path) =>
      _homePath.Combine(path);
    
    private static T Load<T>()
    {
      string path = _pathByType[typeof(T)];
      var textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
      if (textAsset == null) {
        UnityEngine.Debug.LogError($"{typeof(T)} config file not found at {path}");
      }
      
      return YamlReader.Deserialize<T>(textAsset.ToString());
    }
  }
}