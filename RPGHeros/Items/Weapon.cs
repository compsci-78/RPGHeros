using RPGHeros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Items
{
    public class Weapon:Item
    {
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }
    }
}
