namespace infrastructure.services.configs
{
  public interface IConfigsProviderService : IService
  {
    public T Get<T>(string path);
  }
}