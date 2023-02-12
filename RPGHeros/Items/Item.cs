using RPGHeros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot SlotType { get; set; }

        public Item(string name, int requiredLevel, Slot slotType)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            SlotType = slotType;
        }
    }
}
