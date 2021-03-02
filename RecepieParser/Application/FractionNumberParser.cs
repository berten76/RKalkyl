using System.Collections.Generic;

namespace RecepieParser.Application
{
    public static class FractionNumberParser
    {
        public static List<string> RemoveFractionNumbers(List<string> tokens)
        {
            var tokensWithoutFraction = new List<string>();
            for(int i = 0; i < tokens.Count; i++)
            {
                if(i == 0 && i == tokens.Count - 2) continue;

                if(tokens[i] == "/")
                {
                    if(int.TryParse(tokens[i-1], out int beforeInt) &&
                    int.TryParse(tokens[i+1], out int afterInt))
                    {
                        double val = (double)beforeInt / (double)afterInt;
                        int index = i-2;
                        if(index >= 0 && int.TryParse(tokens[index], out int heltal))
                        {
                            val = heltal + val;
                        }
                        tokensWithoutFraction.Add(val.ToString());
                        continue;
                    }
                }

                tokensWithoutFraction.Add(tokens[i]);
            }

            return tokensWithoutFraction;
        }
    }
}