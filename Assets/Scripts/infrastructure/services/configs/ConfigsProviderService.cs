using System;
using infrastructure.services.assets;
using infrastructure.services.serialization;
using UnityEngine;
using static facades.StaticsFacade;

namespace infrastructure.services.configs
{
  public class ConfigsProviderService : IConfigsProviderService
  {
    private readonly ISerializationService _serializationService;
    private readonly IAssetProvider _assetProvider;

    public ConfigsProviderService(IAssetProvider assetProvider, ISerializationService serializationService)
    {
      _assetProvider = assetProvider;
      _serializationService = serializationService;
    }

    public T Get<T>(string path)
    {
      path = StaticConfiguration.ConfigTo(path);
      TextAsset textAsset;
      try {
        textAsset = _assetProvider.Load<TextAsset>(path);
      }
      catch (Exception e) {
        Debug.LogError($"{nameof(ConfigsProviderService)} {nameof(Get)} exception: {e}");
        throw;
      }

      return _serializationService.Deserialize<T>(textAsset.text);
    }
  }
}