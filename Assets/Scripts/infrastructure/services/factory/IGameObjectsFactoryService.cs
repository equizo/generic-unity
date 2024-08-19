using UnityEngine;

namespace infrastructure.services.factory
{
  public interface IGameObjectsFactoryService : IService
  {
    /// <summary>
    /// Create gameObject by path
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    GameObject Create(string path, Transform parent = null);

    /// <summary>
    /// Create by path and GetComponent
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T Create<T>(string path, Transform parent = null);

    /// <summary>
    /// Clone gameObject and GetComponent
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="parent"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T Create<T>(GameObject gameObject, Transform parent = null);
  }
}