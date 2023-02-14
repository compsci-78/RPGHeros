using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public abstract class Hero
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public HeroAttributes LevelAttributes { get; set; }
        public Dictionary<Slot, Item> Equipment { get; set; }
        public List<WeaponType> ValidWeaponTypes { get; set; }
        public List<ArmorType> ValidArmorTypes { get; set; }
        public Hero(string name)
        {
            this.Name = name;
        }
        public abstract void LevelUp();
        /// <summary>
        /// Equping Hero with a valid wapon. Thorws an exeption if Hero doesn't have the required level
        /// or trying to equip an invalid weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InvalidWeaponTypeException"></exception>
        public void Equip(Weapon weapon)
        {

            bool validWepon = false;
            // If weapon level higher than Hero´s Throw an exception
            if (weapon.RequiredLevel > Level)
                throw new InvalidWeaponTypeException("Invalid weapon: Higher level required.");

            // Checking valid weapons
            foreach (var weaponType in ValidWeaponTypes)
            {
                if (weaponType == weapon.WeaponType)
                {
                    Equipment[weapon.SlotType] = weapon;
                    validWepon = true;
                }
            }

            // If weapon not found throw Invalid weapon exception
            if (!validWepon)
                throw new InvalidWeaponTypeException();
        }
        /// <summary>
        /// Equping Hero with a valid armor. Thorws an exeption if Hero doesn't have the required level
        /// or trying to equip an invalid armor.
        /// </summary>
        /// <param name="armor"></param>
        /// <exception cref="InvalidArmorTypeException"></exception>
        public void Equip(Armor armor)
        {
            bool validArmor = false;
            // If weapon level higher than Hero´s Throw an exception
            if (armor.RequiredLevel > Level)
                throw new InvalidArmorTypeException("Invalid armor: Higher level required.");

            // Checking valid armor
            foreach (var armowType in ValidArmorTypes)
            {
                if (armowType == armor.ArmorType)
                {
                    Equipment[armor.SlotType] = armor;
                    validArmor = true;
                }
            }

            // If armor not found throw Invalid armor exception
            if (!validArmor)
                throw new InvalidArmorTypeException();
        }
        public abstract int Damage();
        /// <summary>
        /// Calculating Heros total attributes that is gained from leveling up and equiped armors attribute.
        /// </summary>
        /// <returns>HeroAttributes</returns>
        public HeroAttributes TotalAttributes()
        {
            var totalAttributes = new HeroAttributes();

            foreach (KeyValuePair<Slot, Item> keyValue in Equipment)
            {
                if (keyValue.Key != Slot.Weapon && keyValue.Value !=null)
                    totalAttributes = totalAttributes + ((Armor)keyValue.Value).ArmorAttribute;
            }

            totalAttributes = totalAttributes + LevelAttributes;

            return totalAttributes;
        }
        /// <summary>
        /// Displays current Hero state. 
        /// </summary>
        /// <returns>StringBuilder</returns>
        public StringBuilder Display()
        {
            var totalAttributes = TotalAttributes();

            StringBuilder sb = new StringBuilder();
            sb.Append("Name ..............: " + Name+"\n");
            sb.Append("Level .............: " + Level + "\n");
            sb.Append("Class .............: " + this.GetType().Name + "\n");
            sb.Append("Total strength ....: " + totalAttributes.Strength + "\n");
            sb.Append("Total dexterity ...: " + totalAttributes.Dexterity + "\n");
            sb.Append("Total intelligence : " + totalAttributes.Intelligence + "\n");
            sb.Append("Damage ............: " + Damage() + "\n");

            return sb;
        }
    }
}
