using System;
using configuration.configs;
using YamlDotNet.Serialization;

namespace configuration
{
  [Serializable]
  public class Debug
  {
    [YamlMember(Alias = "state_machine")]
    public StateMachine StateMachine;
    [YamlMember(Alias = "analytics")]
    public ConsoleLine Analytics;
    [YamlMember(Alias = "objects_factory")]
    public ConsoleLine GameObjectsFactory;
    [YamlMember(Alias = "network")]
    public ConsoleLine Network;
    [YamlMember(Alias = "addressable_assets")]
    public ConsoleLine AddressableAssets;
    [YamlMember(Alias = "purchase")]
    public ConsoleLine Purchase;
    [YamlMember(Alias = "content_unlocked")]
    public bool IsContentUnlocked;
    [YamlMember(Alias = "debug_module")]
    public bool DebugModule;
  }
}