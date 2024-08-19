using System.Collections.Generic;
using System.Linq;
using equipment;
using equipment.affix;
using equipment.buff;
using equipment.weapon;
using infrastructure.gameplay.equipment;
using infrastructure.interfaces;
using infrastructure.services.configs;
using infrastructure.services.random;
using static facades.StaticsFacade;

namespace infrastructure.states.implementations.menu_navigation
{
  public class EquipmentState : IState
  {
    private readonly IConfigsProviderService _configsProviderService;
    private readonly IRandomService _randomService;
    private readonly IEquipmentRendererService _equipmentRendererService;

    private const int ItemCount = 16;
    private const int MaxBuffs = 10;

    public EquipmentState(IConfigsProviderService configsProviderService,
                          IRandomService randomService,
                          IEquipmentRendererService equipmentRendererService)
    {
      _equipmentRendererService = equipmentRendererService;
      _randomService = randomService;
      _configsProviderService = configsProviderService;
    }

    public void Enter()
    {
      StaticDebug.Analytics.Print<EquipmentState>("Analytics data sent example");
      _equipmentRendererService.Init(GenerateEquipment(), ItemCount);
    }

    /// <summary>
    /// items' droprate value is ignored, instead all items are taken at random 
    /// </summary>
    /// <returns></returns>
    private List<EquipmentItem> GenerateEquipment()
    {
      var weapons = _configsProviderService.Get<WeaponCollection>(StaticConfiguration.ConfigurationFilesList.Equipment).Weapons;
      var affixes = _configsProviderService.Get<AffixCollection>(StaticConfiguration.ConfigurationFilesList.Affixes).Affixes;

      var equipmentItems = new HashSet<EquipmentItem>();

      for (int i = 0; i < ItemCount; i++) {
        equipmentItems.Add(CreateRandomEquipmentItem(weapons, affixes));
      }

      AssignColors(equipmentItems);
      AddBuffs(equipmentItems);
      return equipmentItems.ToList();
    }

    private EquipmentItem CreateRandomEquipmentItem(List<WeaponWrapper> weapons, List<AffixWrapper> affixes)
    {
      int affixIndex = _randomService.RandomInt(0, affixes.Count);
      int weaponIndex = _randomService.RandomInt(0, weapons.Count);
      return new EquipmentItem(affixes[affixIndex], weapons[weaponIndex]);
    }

    private void AssignColors(HashSet<EquipmentItem> equipmentItems)
    {
      var affixCategories = _configsProviderService.Get<AffixCategoryCollection>(StaticConfiguration.ConfigurationFilesList.AffixesCategory).AffixCategories;
      foreach (var equipmentItem in equipmentItems) {
        var affix = affixCategories.FirstOrDefault(category => category.Name.Equals(equipmentItem.AffixCategory));
        if (affix != null) {
          equipmentItem.SetHexColor(affix.Color);
        }
        else {
          UnityEngine.Debug.LogWarning($"{nameof(equipmentItem.AffixCategory)} {equipmentItem.AffixCategory} not found");
        }
      }
    }

    private void AddBuffs(HashSet<EquipmentItem> equipmentItems)
    {
      var buffs = _configsProviderService.Get<BuffCollection>(StaticConfiguration.ConfigurationFilesList.Buffs).Buffs;

      foreach (var equipmentItem in equipmentItems) {
        var set = new List<BuffWrapper>(buffs);
        int buffsCount = _randomService.RandomInt(MaxBuffs);
        for (int i = 0; i < buffsCount; i++) {
          int index = _randomService.RandomInt(set.Count);
          equipmentItem.AddBuff(set[index]);
          set.RemoveAt(index);
        }
      }
    }

    public void Exit() =>
      _equipmentRendererService.CancelAnimation();
  }
}