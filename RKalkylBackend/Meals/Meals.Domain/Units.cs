using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Domain
{
    public class Units
    {
        public const string g = "g";
        public const string gram = "gram";
        public const string dl = "dl";
        public const string l = "l";
        public const string tsk = "tsk";
        public const string msk = "msk";
        public const string krm = "krm";
        public const string st = "st";
        public const string förp = "förp";

        public static List<string> GetUnits()
        {

            return new List<string>()
            {
                g,
                gram,
                dl,
                l,
                tsk,
                msk,
                krm,
                st,
                förp
            };
        }


    }
    public static class AmountUnit
    {
        public const string g = "g";
        public const string gram = "gram";
        public const string dl = "dl";
        public const string l = "l";
        public const string tsk = "tsk";
        public const string msk = "msk";
        public const string krm = "krm";
        public const string st = "st";
    }
}
