using RPGHeros.Enums;
using RPGHeros.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Items
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public HeroAttributes ArmorAttribute { get; set; }
        public Armor(string name, int requiredLevel, Slot slotType, ArmorType armorType, HeroAttributes armorAttribute) : base(name, requiredLevel, slotType)
        {
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }
    }
}
