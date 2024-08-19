namespace infrastructure.services.random
{
  public interface IRandomService : IService
  {
    int RandomInt(int a, int b);
    int RandomInt(int b);
    float RandomValue();
  }
}