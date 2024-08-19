using infrastructure.services.assets;
using UnityEngine;
using static facades.StaticsFacade;
using Object = UnityEngine.Object;

namespace infrastructure.services.factory
{
  public class GameObjectsFactoryService : IGameObjectsFactoryService
  {
    private readonly IAssetProvider _assetProvider;

    // private Transform SafeArea =>
    // SharedUiEnvironment.SafeArea;

    // private Transform FullScreenAreaBackground =>
    //     SharedUiEnvironment.FullScreenAreaBackground;
    //
    // private Transform FullScreenAreaForeground =>
    //     SharedUiEnvironment.FullScreenAreaForeground;

    public GameObjectsFactoryService(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public T Create<T>(string path, Transform parent = null) =>
      Create(path, parent).GetComponent<T>();

    public T Create<T>(GameObject gameObject, Transform parent = null) =>
      Create(gameObject, parent).GetComponent<T>();

    public GameObject Create(string path, Transform parent = null)
    {
      DebugAction(path, parent);
      return Object.Instantiate(_assetProvider.Load<GameObject>(path), parent);
    }

    private GameObject Create(GameObject gameObject, Transform parent = null)
    {
      DebugAction(gameObject.name, parent);
      return Object.Instantiate(gameObject, parent);
    }

    private void DebugAction(string path, Transform parent)
    {
      string parentPath = parent == null ? string.Empty : $"; under {parent.gameObject.name}";
      StaticDebug.GameObjectsFactory.Print<GameObjectsFactoryService>($"creates {path.Split('\\')[^1]}{parentPath}\n{path}");
    }
  }
}