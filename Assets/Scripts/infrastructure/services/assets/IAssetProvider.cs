using UnityEngine;

namespace infrastructure.services.assets
{
  /// <summary>
  /// Assets provider either from Resources, addressable assets, assets bundles 
  /// </summary>
  public interface IAssetProvider : IService
  {
    T   Load<T>(string path) where T : Object;
    T[] LoadAll<T>(string path) where T : Object;
  }
}