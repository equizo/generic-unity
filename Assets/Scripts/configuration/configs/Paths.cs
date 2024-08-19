using System;
using extensions;
using YamlDotNet.Serialization;

namespace configuration.configs
{
  [Serializable]
  public class Paths
  {
    [YamlMember(Alias = "base_camera")]
    public string BaseCamera;
    [YamlMember(Alias = "prefabs")]
    public string Prefabs;
    [YamlMember(Alias = "screen")]
    public string Screen;
    [YamlMember(Alias = "ui_equipment")]
    public string UiEquipment;
    [YamlMember(Alias = "ui_buff")]
    public string UiBuff;
    [YamlMember(Alias = "desktop_directory")]
    public string DesktopDirectory;
    [YamlMember(Alias = "mobile_directory")]
    public string MobileDirectory;
    [YamlMember(Alias = "scene_environment")]
    public string SceneEnvironment;
    [YamlMember(Alias = "ui_environment")]
    public string UiEnvironment;
    [YamlMember(Alias = "icons")]
    public string Icons;

    public string Prefab(string path) =>
      Prefabs.Combine(path);
  }
}