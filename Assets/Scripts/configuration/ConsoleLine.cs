using System;
using System.Linq;
using YamlDotNet.Serialization;

namespace configuration
{
  [Serializable]
  public class ConsoleLine
  {
    [YamlMember(Alias = "print")]
    public bool IsPrinting;
    [YamlMember(Alias = "color")]
    public string Color;

    public virtual void Print<T>(string text, string prefix = "")
    {
      if (IsPrinting) {
        UnityEngine.Debug.Log($"{prefix} <color={Color}>{typeof(T).ToString().Split('.').Last()}</color> {text}".Trim());
      }
    }
  }
}