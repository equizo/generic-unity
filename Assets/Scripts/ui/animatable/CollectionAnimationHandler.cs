using System.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using System.Threading;

namespace ui.animatable
{
  public class CollectionAnimationHandler
  {
    /// <summary>
    /// To be extracted to a config
    /// </summary>
    private const float AnimationDuration = 2f;
    private const float DelayMilliSeconds = 10f;

    private CancellationTokenSource _cancellationTokenSource = new();

    public async Task AnimateAsync(List<IAnimatableCanvasGroup> items)
    {
      Cancel();
      _cancellationTokenSource = new CancellationTokenSource();
      CancellationToken token = _cancellationTokenSource.Token;

      int itemsCount = items.Count;

      for (int i = 0; i < itemsCount; i++) {
        items[i].CanvasGroup.alpha = 0;
      }
      
      for (var i = 0; i < itemsCount; i++) {
        float itemDuration = AnimationDuration * (0 + ((float) i + 1) / itemsCount);
        token.ThrowIfCancellationRequested();
        items[i].CanvasGroup.DOFade(1f, itemDuration);
        await Task.Delay((int)(itemDuration * DelayMilliSeconds), token);
      }
    }

    public void Cancel() =>
      _cancellationTokenSource.Cancel();
  }
}