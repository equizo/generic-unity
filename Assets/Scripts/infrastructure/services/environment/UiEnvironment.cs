using System;
using configuration.wrappers;
using ui;
using ui_navigation;
using UnityEngine;

namespace infrastructure.services.environment
{
  public abstract class UiEnvironment : MonoBehaviour, IUiEnvironment
  {
    #region Editor references

    [SerializeField] private UiScreenInfo uiScreenInfo;
    [field: SerializeField] public Transform ScreensHolder { get; private set; }

    #endregion

    protected Action ForwardAction = () => { };
    protected Action BackAction = () => { };

    public void SetScreenInfo(ScreenWrapper screenWrapper) =>
      uiScreenInfo.Init(screenWrapper);

    public abstract void InitNavigation(ActionsPair actionPair);
  }
}