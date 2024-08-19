using TMPro;

namespace ui
{
  public interface IScreenAnimator
  {
    void AnimateTitle(TMP_Text text, string title);
    void AnimateDescription(TMP_Text text, string subtitle);
  }
}