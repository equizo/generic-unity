using UnityEngine;
using UnityEngine.UI;

namespace ui
{
  public class UiBuff : MonoBehaviour, IUiBuff
  {
    #region Editor references

    [SerializeField] private Image _image;

    #endregion
    
    public void Init(Sprite sprite) =>
      _image.sprite = sprite;
  }
}