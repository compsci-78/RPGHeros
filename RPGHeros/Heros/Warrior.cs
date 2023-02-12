using RPGHeros.Enums;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            Level = 1;
            LevelAttributes = new HeroAttributes() { Strength = 5, Dexterity = 2, Intelligence = 1 };

            Equipment = new Dictionary<Enums.Slot, Item>(4);
            Equipment.Add(Slot.Weapon, null);
            Equipment.Add(Slot.Head, null);
            Equipment.Add(Slot.Body, null);
            Equipment.Add(Slot.Legs, null);

            ValidWeaponTypes = new List<WeaponType>();
            ValidWeaponTypes.Add(WeaponType.Axes);
            ValidWeaponTypes.Add(WeaponType.Hammers);
            ValidWeaponTypes.Add(WeaponType.Swords);

            ValidArmorTypes = new List<ArmorType>();
            ValidArmorTypes.Add(ArmorType.Mail);
            ValidArmorTypes.Add(ArmorType.Plate);
        }

        public override int Damage()
        {
            var weponDamage = Equipment[Slot.Weapon] == null ? 1 : ((Weapon)Equipment[Slot.Weapon]).WeaponDamage;
            var totalAttributes = TotalAttributes();

            return weponDamage * (1 + (totalAttributes.Strength / 100));
        }

        public override void LevelUp()
        {
            Level += 1;
            var newHerroAttributes = new HeroAttributes() { Strength = 3, Dexterity = 2, Intelligence = 1 };
            LevelAttributes = LevelAttributes + newHerroAttributes;
        }

    }
}
