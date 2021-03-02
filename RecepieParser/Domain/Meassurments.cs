using System.Collections.Generic;

namespace RecepieParser.Domain
{
    public class Meassurments
    {
        public IEnumerable<string> GetMeassurments()
        {
            return new List<string>()
            {
                "dl",
                "l",
                "burk",
                "msk",
                "tsk"
            };
        }
    }
}