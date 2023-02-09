using RPGHeros.Enums;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            Level = 1;
            LevelAttributes = new HeroAttributes() { Strength = 1, Dexterity = 1,Intelligence=8 };
            Equipment = new Dictionary<Enums.Slot, Item>(4);
            Equipment.Add(Slot.Weapon,null);
            Equipment.Add(Slot.Head, null);
            Equipment.Add(Slot.Body, null);
            Equipment.Add(Slot.Legs, null);

            ValidWeaponTypes = new List<WeaponType>();
            ValidWeaponTypes.Add(WeaponType.Staffs);
            ValidWeaponTypes.Add(WeaponType.Wands);

            ValidArmorTypes = new List<ArmorType>();
            ValidArmorTypes.Add(ArmorType.Cloth);
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
            throw new NotImplementedException();
        }

        public override HeroAttributes TotalAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
