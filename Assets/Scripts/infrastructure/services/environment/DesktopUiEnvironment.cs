using System;
using ui_navigation;
using UnityEngine;
using UnityEngine.UI;

namespace infrastructure.services.environment
{
  public class DesktopUiEnvironment : UiEnvironment
  {
    #region Editor references

    [SerializeField] private Button _backButton;
    [SerializeField] private Button _forwardButton;

    #endregion

    private void Awake()
    {
      _backButton.onClick.AddListener(OnBack);
      _forwardButton.onClick.AddListener(OnForward);
    }

    private void OnBack() =>
      BackAction.Invoke();

    private void OnForward() =>
      ForwardAction.Invoke();

    public override void InitNavigation(ActionsPair actionPair)
    {
      BackAction = actionPair.OnBack;
      ForwardAction = actionPair.OnForward;
      ToggleButtonState(_backButton, BackAction);
      ToggleButtonState(_forwardButton, ForwardAction);
    }

    private void ToggleButtonState(Button button, Action action) =>
      button.interactable = action != null;
  }
}