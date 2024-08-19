using System.Collections.Generic;
using equipment.affix;
using equipment.buff;
using equipment.weapon;

namespace equipment
{
  public class EquipmentItem
  {
    private readonly AffixWrapper _affix;
    private readonly WeaponWrapper _weapon;

    public string HexColor { get; private set; } = "#FFFFFF";

    public string WeaponIcon =>
      _weapon.Icon;

    public string AffixCategory =>
      _affix.Category;

    public List<BuffWrapper> Buffs { get; } = new();
    
    public string Name =>
      $"{_affix.Name} {_weapon.Name}";

    public string Info =>
      $"{_affix.Name} {_weapon.Name}\ndmg: {_weapon.Damage.Min}-{_weapon.Damage.Min}\n{_affix.Description}\n{_affix.Category}";

    public EquipmentItem(AffixWrapper affix, WeaponWrapper weapon)
    {
      _weapon = weapon;
      _affix = affix;
    }

    public void SetHexColor(string value) =>
      HexColor = value;

    public void AddBuff(BuffWrapper buff) =>
      Buffs.Add(buff);
  }
}