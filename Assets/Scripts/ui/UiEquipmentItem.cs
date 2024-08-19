using equipment;
using extensions;
using infrastructure.services.assets;
using infrastructure.services.factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static facades.StaticsFacade;

namespace ui
{
  public class UiEquipmentItem : MonoBehaviour, IUiEquipmentItem
  {
    #region Editor references

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _buffsText;
    [SerializeField] private Transform _buffsHolder;
    [SerializeField] private GameObject _buffsSection;
    [field:SerializeField] public CanvasGroup CanvasGroup { get; private set; }

    #endregion

    private EquipmentItem _equipmentItem;
    private ICachedSpritesProviderService _cachedSpritesProvider;
    private IGameObjectsFactoryService _gameObjectsFactoryService;

    public void Init(EquipmentItem equipmentItem,
                     ICachedSpritesProviderService cachedSpritesProvider,
                     IGameObjectsFactoryService gameObjectsFactoryService)
    {
      _gameObjectsFactoryService = gameObjectsFactoryService;
      _cachedSpritesProvider = cachedSpritesProvider;
      _equipmentItem = equipmentItem;
      _name.SetText(equipmentItem.Name);
      SetTextColor();
      SetIcon();
      SetBuffs();
    }

    private void SetTextColor()
    {
      if (!ColorUtility.TryParseHtmlString(_equipmentItem.HexColor, out var color)) {
        color = Color.white;
      }

      _name.color = color;
    }

    private void SetIcon() =>
      _icon.sprite = LoadSprite(_equipmentItem.WeaponIcon);

    private void SetBuffs()
    {
      var buffs = _equipmentItem.Buffs;
      int buffsCount = buffs.Count;
      if (buffsCount == 0) {
        _buffsSection.SetActive(false);
        return;
      }
      
      for (var i = 0; i < buffsCount; i++) {
        var sprite = LoadSprite(buffs[i].Icon);
        _gameObjectsFactoryService.Create<IUiBuff>(StaticPaths.Prefab(StaticPaths.UiBuff), _buffsHolder).Init(sprite);
      }
      
      _buffsText.SetText($"Buffs ({buffsCount})");
    }

    private Sprite LoadSprite(string path) =>
      _cachedSpritesProvider.Load(StaticPaths.Icons.Combine(path));
  }
}