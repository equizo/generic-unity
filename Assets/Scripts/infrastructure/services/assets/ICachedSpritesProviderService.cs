using UnityEngine;

namespace infrastructure.services.assets
{
  public interface ICachedSpritesProviderService : IService
  {
    Sprite Load(string path);
  }
}