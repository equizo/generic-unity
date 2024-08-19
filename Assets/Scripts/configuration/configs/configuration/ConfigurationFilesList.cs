using System;
using YamlDotNet.Serialization;

namespace configuration.configs.configuration
{
  [Serializable]
  public class ConfigurationFilesList
  {
    [YamlMember(Alias = "home")]
    public string HomeDirectory;
    [YamlMember(Alias = "screens")]
    public string UiScreens;
    [YamlMember(Alias = "equipment")]
    public string Equipment;
    [YamlMember(Alias = "affixes")]
    public string Affixes;
    [YamlMember(Alias = "affixes_category")]
    public string AffixesCategory;
    [YamlMember(Alias = "buffs")]
    public string Buffs;
  }
}