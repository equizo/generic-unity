using ui_navigation;
using UnityEngine;

namespace infrastructure.services.environment
{
  public class MobileUiEnvironment : UiEnvironment
  {
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private const float MinSwipeDistanceSqr = 50f * 50f;

    public override void InitNavigation(ActionsPair actionPair)
    {
      BackAction = actionPair.OnBack;
      ForwardAction = actionPair.OnForward;
    }

    private void Update()
    {
      DetectSwipe();
      // TestInEditor();
    }

    private void DetectSwipe()
    {
      if (Input.touchCount <= 0) {
        return;
      }

      Touch touch = Input.GetTouch(0);
      var touchPosition = touch.position;
      switch (touch.phase) {
        case TouchPhase.Began:
          _startPosition = touchPosition;
          break;

        case TouchPhase.Ended:
          _endPosition = touchPosition;
          HandleSwipe();
          break;
      }
    }

    private void TestInEditor()
    {
      var mousePosition = Input.mousePosition;
      if (Input.GetMouseButtonDown(0)) {
        _startPosition = mousePosition;
      }
      else
        if (Input.GetMouseButtonUp(0)) {
          _endPosition = mousePosition;
          HandleSwipe();
        }
    }

    private void HandleSwipe()
    {
      float distance = Vector2.SqrMagnitude(_startPosition - _endPosition);
      bool shallIgnore = distance < MinSwipeDistanceSqr;
      if (shallIgnore) {
        return;
      }

      Vector2 direction = (_endPosition - _startPosition).normalized;
      float directionX = direction.x;
      float directionY = direction.y;

      if (Mathf.Abs(directionX) <= Mathf.Abs(directionY)) {
        return;
      }

      if (directionX > 0) {
        OnSwipeRight();
      }
      else {
        OnSwipeLeft();
      }
    }

    private void OnSwipeRight() =>
      BackAction?.Invoke();

    private void OnSwipeLeft() =>
      ForwardAction?.Invoke();
  }
}