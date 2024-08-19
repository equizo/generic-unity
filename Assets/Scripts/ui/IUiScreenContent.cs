using ui.animatable;
using UnityEngine;

namespace ui
{
  public interface IUiScreenContent : IAnimatableCanvasGroup, IAnimatableRectTransform
  {
    GameObject Content               { get; }
    Transform  ScreenSpecificContent { get; set; }
    void       Enable();
    void       Disable();
  }
}