using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace infrastructure.services.assets
{
  public class ResourceAssetProvider : IAssetProvider
  {
    public T Load<T>(string path) where T : Object
    {
      var asset = Resources.Load<T>(path);
      if (asset == null) {
        Debug.LogError($"Asset not found in \"{path}\"");
      }

      return asset;
    }

    public T[] LoadAll<T>(string path) where T : Object
    {
      var assets = Resources.LoadAll(path, typeof(T));
      if (assets == null) {
        Debug.LogError($"Assets not found in \"{path}\"");
        return Array.Empty<T>();
      }

      int assetsLength = assets.Length;
      var array = new T[assetsLength];
      for (int i = 0; i < assetsLength; i++) {
        array[i] = (T) assets[i];
      }

      return array;
    }
  }
}