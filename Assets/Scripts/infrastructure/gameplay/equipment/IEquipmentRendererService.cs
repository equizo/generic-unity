using System.Collections.Generic;
using equipment;
using infrastructure.services;
using ui.animatable;

namespace infrastructure.gameplay.equipment
{
  public interface IEquipmentRendererService : IService, IAnimationHolder
  {
    void Init(List<EquipmentItem> generateEquipment, int itemCount);
  }
}