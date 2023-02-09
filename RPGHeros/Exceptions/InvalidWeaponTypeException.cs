using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Exceptions
{
    public class InvalidWeaponTypeException:Exception
    {
        public InvalidWeaponTypeException() { }
        public InvalidWeaponTypeException (string message) : base(message) { }

        public override string Message => "Invalid weapon type."; 

    }
}
