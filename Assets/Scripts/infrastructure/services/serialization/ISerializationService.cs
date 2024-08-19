namespace infrastructure.services.serialization
{
  public interface ISerializationService : IService
  {
    public string Serialize(object data);
    public T      Deserialize<T>(string text);
  }
}