using UnityEngine;

namespace ui
{
  public class UiScreenContent : MonoBehaviour, IUiScreenContent
  {
    #region Editor references

    [field: SerializeField] public GameObject    Content       { get; private set; }
    [field: SerializeField] public CanvasGroup   CanvasGroup   { get; private set; }
    [field: SerializeField] public RectTransform RectTransform { get; private set; }

    #endregion

    public Transform ScreenSpecificContent { get; set; }

    public void Enable() =>
      ToggleContent(true);

    public void Disable() =>
      ToggleContent(false);

    private void ToggleContent(bool isOn) =>
      Content.SetActive(isOn);
  }
}