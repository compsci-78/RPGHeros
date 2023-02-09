using RPGHeros.Enums;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            Level = 1;
            LevelAttributes = new HeroAttributes() { Strength = 2, Dexterity = 6, Intelligence = 1 };
         
            Equipment = new Dictionary<Enums.Slot, Item>(4);
            Equipment.Add(Slot.Weapon, null);
            Equipment.Add(Slot.Head, null);
            Equipment.Add(Slot.Body, null);
            Equipment.Add(Slot.Legs, null);

            ValidWeaponTypes = new List<WeaponType>();
            ValidWeaponTypes.Add(WeaponType.Daggers);
            ValidWeaponTypes.Add(WeaponType.Swords);

            ValidArmorTypes = new List<ArmorType>();
            ValidArmorTypes.Add(ArmorType.Leather);
            ValidArmorTypes.Add(ArmorType.Mail);
        }

        public override int Damage()
        {
            throw new NotImplementedException();
        }

        public override void Equip(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public override void Equip(Armor armor)
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
            Level += 1;
            var newLevel = new HeroAttributes() { Strength = 1, Dexterity = 4, Intelligence = 1 };
            LevelAttributes = LevelAttributes + newLevel;
        }

        public override HeroAttributes TotalAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
