namespace infrastructure.services
{
  public class AllServices
  {
    private static readonly AllServices Instance;
    public static readonly AllServices Container = Instance ??= new AllServices();

    public void RegisterSingle<TService>(TService implementation) where TService : IService =>
      Implementation<TService>.ServiceInstance = implementation;

    public TService Single<TService>() where TService : IService =>
      Implementation<TService>.ServiceInstance;

    private static class Implementation<TService> where TService : IService
    {
      public static TService ServiceInstance;
    }
  }
}