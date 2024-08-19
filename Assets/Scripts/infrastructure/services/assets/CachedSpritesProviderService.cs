using System.Collections.Generic;
using UnityEngine;

namespace infrastructure.services.assets
{
  public class CachedSpritesProviderService : ICachedSpritesProviderService
  {
    private readonly IAssetProvider _assetProvider;

    private readonly Dictionary<string, Sprite> _spritesByPath = new();

    public CachedSpritesProviderService(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public Sprite Load(string path)
    {
      if (!_spritesByPath.TryGetValue(path, out var sprite)) {
        sprite = _assetProvider.Load<Sprite>(path);
        _spritesByPath.Add(path, sprite);
      }

      return sprite;
    }
  }
}