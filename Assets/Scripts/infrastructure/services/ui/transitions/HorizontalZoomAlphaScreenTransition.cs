using System;
using DG.Tweening;
using ui;

namespace infrastructure.services.ui.transitions
{
  public class HorizontalZoomAlphaScreenTransition : IScreenTransition
  {
    public void Animate(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen, Action onFinish)
    {
      const float duration = 0.25f;
      const float scale = 0.65f;
      const float showDistance = 800;
      const float fadeDistance = 800;

      newUiScreen.RectTransform.DOAnchorPosX(showDistance, 0f);
      newUiScreen.RectTransform.DOScaleY(scale, 0f);
      newUiScreen.CanvasGroup.alpha = 0f;
      newUiScreen.Enable();
      DOTween.Sequence()
        .Append(activeUiScreen.RectTransform.DOAnchorPosX(-fadeDistance, duration))
        .Join(activeUiScreen.RectTransform.DOScaleY(scale, duration))
        .Join(activeUiScreen.CanvasGroup.DOFade(0f, duration))
        .OnComplete(activeUiScreen.Disable)
        .Play();

      DOTween.Sequence()
        .Append(newUiScreen.RectTransform.DOAnchorPosX(0, duration))
        .Join(newUiScreen.RectTransform.DOScaleY(1f, duration))
        .Join(newUiScreen.CanvasGroup.DOFade(1f, duration))
        .OnComplete(onFinish.Invoke)
        .Play();
    }
  }
}