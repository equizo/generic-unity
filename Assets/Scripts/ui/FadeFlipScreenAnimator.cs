using DG.Tweening;
using TMPro;

namespace ui
{
  public class FadeFlipScreenAnimator : IScreenAnimator
  {
    /// <summary>
    /// Could be extracted to global animation config or scriptable object
    /// </summary>
    private const float Duration = 0.25f;

    public void AnimateTitle(TMP_Text text, string title) =>
      DOTween.Sequence()
        .Append(text.DOFade(0f, Duration))
        .AppendCallback(() => text.SetText(title))
        .Append(text.DOFade(1f, Duration))
        .Play();

    public void AnimateDescription(TMP_Text text, string subtitle) =>
      DOTween.Sequence()
        .Append(text.transform.DOScaleY(0f, Duration))
        .AppendCallback(() => text.SetText(subtitle))
        .Append(text.transform.DOScaleY(1f, Duration))
        .Play();
  }
}