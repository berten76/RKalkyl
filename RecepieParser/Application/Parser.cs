using System.Collections.Generic;

namespace RecepieParser.Application
{
    public class Parser
    {
        public void Parse(string input)
        {
            var tokens = input.Split(' ');
            var tokens2 = FractionNumberParser.RemoveFractionNumbers(new List<string>(tokens));
        }
    }
}