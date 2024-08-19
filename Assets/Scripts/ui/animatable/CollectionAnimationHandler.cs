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

    private CancellationTokenSource _cancellationTokenSource = new();

    public async Task AnimateAsync(List<IAnimatableCanvasGroup> items)
    {
      Cancel();
      _cancellationTokenSource = new CancellationTokenSource();
      CancellationToken token = _cancellationTokenSource.Token;

      int itemsCount = items.Count;
      float baseDuration = AnimationDuration / itemsCount;
      for (var i = 0; i < itemsCount; i++) {
        token.ThrowIfCancellationRequested();
        await items[i].CanvasGroup.DOFade(1f, baseDuration).AsyncWaitForCompletion();
      }
    }

    public void Cancel() =>
      _cancellationTokenSource.Cancel();
  }
}