using configuration.wrappers;
using TMPro;
using UnityEngine;

namespace ui
{
  public class UiScreenInfo : MonoBehaviour
  {
    #region Editor references

    [SerializeField] private TMP_Text _screenTitle;
    [SerializeField] private TMP_Text _screenDescription;

    #endregion

    public void Init(ScreenWrapper screenWrapper)
    {
      bool isNameEmpty = _screenTitle.text[0] == '#';
      if (isNameEmpty) {
        _screenTitle.SetText(screenWrapper.Title);
        _screenDescription.SetText(screenWrapper.SubTitle);
        return;
      }

      IScreenAnimator screenAnimator = new FadeFlipScreenAnimator();
      screenAnimator.AnimateTitle(_screenTitle, screenWrapper.Title);
      screenAnimator.AnimateDescription(_screenDescription, screenWrapper.SubTitle);
    }
  }
}