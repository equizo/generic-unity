using System;
using configuration.configs.configuration;
using extensions;
using YamlDotNet.Serialization;

namespace configuration.configs
{
  [Serializable]
  public class Configuration
  {
    [YamlMember(Alias = "screen")]
    public Screen Screen;
    [YamlMember(Alias = "configuration_files")]
    public ConfigurationFilesList ConfigurationFilesList;
    [YamlMember(Alias = "ccd")]
    public UnityCcdConfig Ccd;
    
    public string ConfigTo(string path) =>
      ConfigurationFilesList.HomeDirectory.Combine(path);
  }
}