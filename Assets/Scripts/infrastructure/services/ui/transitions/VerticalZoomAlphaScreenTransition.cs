using System;
using DG.Tweening;
using ui;

namespace infrastructure.services.ui.transitions
{
  public class VerticalZoomAlphaScreenTransition : IScreenTransition
  {
    public void Animate(IUiScreenContent activeUiScreen, IUiScreenContent newUiScreen, Action onFinish)
    {
      const float duration = 0.25f;
      const float scale = 0.75f;
      const float showDistance = 200;
      const float fadeDistance = 400;

      newUiScreen.RectTransform.DOAnchorPosY(showDistance, 0f);
      newUiScreen.RectTransform.DOScaleX(scale, 0f);
      newUiScreen.CanvasGroup.alpha = 0f;
      newUiScreen.Enable();
      DOTween.Sequence()
        .Append(activeUiScreen.RectTransform.DOAnchorPosY(-fadeDistance, duration))
        .Join(activeUiScreen.RectTransform.DOScaleX(scale, duration))
        .Join(activeUiScreen.CanvasGroup.DOFade(0f, duration))
        .OnComplete(activeUiScreen.Disable)
        .Play();

      DOTween.Sequence()
        .Append(newUiScreen.RectTransform.DOAnchorPosY(0, duration))
        .Join(newUiScreen.RectTransform.DOScaleX(1f, duration))
        .Join(newUiScreen.CanvasGroup.DOFade(1f, duration))
        .OnComplete(onFinish.Invoke)
        .Play();
    }
  }
}