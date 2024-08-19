using equipment;
using infrastructure.services.assets;
using infrastructure.services.factory;
using ui.animatable;

namespace ui
{
  public interface IUiEquipmentItem : IAnimatableCanvasGroup
  {
    void Init(EquipmentItem equipmentItem,
              ICachedSpritesProviderService cachedSpritesProviderService,
              IGameObjectsFactoryService gameObjectsFactoryService);
  }
}