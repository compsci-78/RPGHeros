using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Heros
{
    public class HeroAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is HeroAttributes attributes &&
                   Strength == attributes.Strength &&
                   Dexterity == attributes.Dexterity &&
                   Intelligence == attributes.Intelligence;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength, Dexterity, Intelligence);
        }
        /// <summary>
        /// Operator overloading that defines how two instances og HeroAttribute should add gether
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>HeroAttribute</returns>
        public static HeroAttributes operator +(HeroAttributes leftSide, HeroAttributes rightSide)
        {
            return new HeroAttributes()
            {
                Strength = leftSide.Strength + rightSide.Strength,
                Dexterity = leftSide.Dexterity + rightSide.Dexterity,
                Intelligence = leftSide.Intelligence + rightSide.Intelligence
            };
        }
    }
}
