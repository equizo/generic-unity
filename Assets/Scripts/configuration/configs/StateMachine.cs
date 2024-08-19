using System;
using System.Text;
using YamlDotNet.Serialization;

namespace configuration.configs
{
  [Serializable]
  public class StateMachine : ConsoleLine
  {
    [YamlMember(Alias = "start")]
    public string StartState;

    public override void Print<T>(string text, string prefix = "")
    {
      if (!IsPrinting) {
        return;
      }

      string stateName = typeof(T).ToString().Split('.')[^1];
      var stringBuilder = new StringBuilder();
      for (var i = 0; i < stateName.Length - "State".Length; i++) {
        if (char.IsUpper(stateName[i])) {
          stringBuilder.Append(" ");
        }

        stringBuilder.Append(stateName[i]);
      }

      stringBuilder.Append(" state");
      UnityEngine.Debug.Log($"{prefix} <color={Color}>{stringBuilder}</color> {text}".Trim());
    }
  }
}