using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeros.Exceptions
{
    public class InvalidArmorTypeException:Exception
    {
        public InvalidArmorTypeException() { }

        public InvalidArmorTypeException(string message) : base(message) { }

        public override string Message => "Invalid armor type.";

    }
}
