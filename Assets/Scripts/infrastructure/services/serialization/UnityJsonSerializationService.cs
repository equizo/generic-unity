using UnityEngine;

namespace infrastructure.services.serialization
{
  public class UnityJsonSerializationService : ISerializationService
  {
    public string Serialize(object data) =>
      JsonUtility.ToJson(data);

    public T Deserialize<T>(string text) =>
      JsonUtility.FromJson<T>(text);
  }
}