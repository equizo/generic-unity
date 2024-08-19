using System.Collections.Generic;
using equipment;
using infrastructure.services.assets;
using infrastructure.services.factory;
using infrastructure.services.ui;
using infrastructure.states.implementations.menu_navigation;
using ui;
using ui.animatable;
using UnityEngine;
using static facades.StaticsFacade;

namespace infrastructure.gameplay.equipment
{
  public class EquipmentRendererService : IEquipmentRendererService
  {
    private IUiScreenContent _screenContent;
    private readonly IScreenEntityProvider _screenEntityProvider;
    private readonly IGameObjectsFactoryService _gameObjectsFactoryService;
    private readonly ICachedSpritesProviderService _cachedSpritesProvider;
    private readonly CollectionAnimationHandler _collectionAnimationHandler;

    public EquipmentRendererService(IScreenEntityProvider screenEntityProvider,
                                    IGameObjectsFactoryService gameObjectsFactoryService,
                                    ICachedSpritesProviderService cachedSpritesProvider)
    {
      _cachedSpritesProvider = cachedSpritesProvider;
      _gameObjectsFactoryService = gameObjectsFactoryService;
      _screenEntityProvider = screenEntityProvider;
      _collectionAnimationHandler = new CollectionAnimationHandler();
    }

    public void Init(List<EquipmentItem> equipmentItems, int itemCount)
    {
      _screenContent = _screenEntityProvider.GetScreenContent<EquipmentState>();

      Clear();
      List<IAnimatableCanvasGroup> uiEquipmentItems = new List<IAnimatableCanvasGroup>();
      for (int i = 0; i < itemCount; i++) {
        var uiEquipmentItem = _gameObjectsFactoryService.Create<IUiEquipmentItem>(
          StaticPaths.Prefab(StaticPaths.UiEquipment),
          _screenContent.ScreenSpecificContent);
        uiEquipmentItem.Init(equipmentItems[i], _cachedSpritesProvider, _gameObjectsFactoryService);
        uiEquipmentItem.CanvasGroup.alpha = 0;
        uiEquipmentItems.Add(uiEquipmentItem);
      }

      _collectionAnimationHandler.AnimateAsync(uiEquipmentItems);
    }

    /// <summary>
    /// Reusing objects in a manner of object pool will be more efficient 
    /// </summary>
    private void Clear()
    {
      for (int i = _screenContent.ScreenSpecificContent.childCount - 1; i >= 0; i--) {
        Object.Destroy(_screenContent.ScreenSpecificContent.GetChild(i).gameObject);
      }
    }

    public void CancelAnimation() =>
      _collectionAnimationHandler.Cancel();
  }
}