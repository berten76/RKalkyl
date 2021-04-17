using System;

namespace RKalkylMath
{
    public static class Fractional
    {
        public static bool IsFractional(string data)
        {
            return data.Contains('/');
        }
        public static double ToDecimal(string data)
        {
            double final = 0;

            foreach (string s in data.Split(' '))
            {
                if (IsFractional(s))
                {
                    final += double.Parse(s.Split('/')[0]) / double.Parse(s.Split('/')[1]);
                }
                else
                {
                    double tryparse = 0;
                    double.TryParse(s, out tryparse);
                    final += tryparse;
                }
            }

            return final;
        }
    }
}
