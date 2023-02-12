using RPGHeros.Enums;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            Level = 1;
            LevelAttributes = new HeroAttributes() { Strength = 1, Dexterity = 7, Intelligence = 1 };
           
            Equipment = new Dictionary<Enums.Slot, Item>(4);
            Equipment.Add(Slot.Weapon, null);
            Equipment.Add(Slot.Head, null);
            Equipment.Add(Slot.Body, null);
            Equipment.Add(Slot.Legs, null);

            ValidWeaponTypes = new List<WeaponType>();
            ValidWeaponTypes.Add(WeaponType.Bows);            

            ValidArmorTypes = new List<ArmorType>();
            ValidArmorTypes.Add(ArmorType.Leather);
            ValidArmorTypes.Add(ArmorType.Mail);
        }

        public override int Damage()
        {
            var weponDamage = Equipment[Slot.Weapon] == null ? 1 : ((Weapon)Equipment[Slot.Weapon]).WeaponDamage;
            var totalAttributes = TotalAttributes();

            return weponDamage * (1 + (totalAttributes.Dexterity / 100));
        }
        public override void LevelUp()
        {
            Level += 1;
            var newHerroAttributes = new HeroAttributes() { Strength = 1, Dexterity = 5, Intelligence = 1 };
            LevelAttributes = LevelAttributes + newHerroAttributes;
        }
    }
}
