namespace infrastructure.services.random
{
  public class UnityRandomService : IRandomService
  {
    public int RandomInt(int a, int b) =>
      UnityEngine.Random.Range(a, b);

    public int RandomInt(int b) =>
      RandomInt(0, b);

    public float RandomValue() =>
      UnityEngine.Random.value;
  }
}