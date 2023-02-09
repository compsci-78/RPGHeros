﻿using RPGHeros.Enums;
using RPGHeros.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public HeroAttributes Level { get; set; }
        public HeroAttributes LevelAttributes { get; set; }
        public Dictionary<Slot,Item> Equipment { get; set; }
        public List<Item> ValidWeaponTypes{ get; set; }
        public List<Item> ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            this.Name = name;
        }
        public abstract void LevelUp();
        public abstract void Equip(Weapon weapon);
        public abstract void Equip(Armor armor);
        public abstract int Damage();
        public abstract HeroAttributes TotalAttributes();
        public void Display() { }
    }
}