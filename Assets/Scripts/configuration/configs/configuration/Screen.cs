using System;
using YamlDotNet.Serialization;

namespace configuration.configs.configuration
{
  [Serializable]
  public class Screen
  {
    [YamlMember(Alias = "fps")]
    public int Fps;
  }
}