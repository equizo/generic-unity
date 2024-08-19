using YamlDotNet.Serialization;

namespace configuration
{
  public static class YamlReader
  {
    public static T Deserialize<T>(string text) =>
      new DeserializerBuilder().Build().Deserialize<T>(text);
  }
}