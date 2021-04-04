using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Domain
{
    public class Units
    {
        public static List<string> GetUnits()
        {
            return new List<string>()
            {
                "g",
                "gram",
                "dl",
                "l",
                "tsk",
                "msk",
            };
        }
    }
}
