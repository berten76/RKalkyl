using System;
using System.IO;
using System.Linq;

namespace SortingData
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\sechber7\source\repos\private\RKalkyl\RKalkyl\Persistance\LivsmedelsDB_202102212044.csv";

            if (File.Exists(file))
            {
                var lines = System.IO.File.ReadAllLines(file).ToList();

                lines.Sort((x, y) => string.Compare(x.Split(" ")[0], y.Split(" ")[0]));

                File.WriteAllLines(@"C:\Users\sechber7\source\repos\private\RKalkyl\RKalkyl\Persistance\LivsmedelsDB_202102212044_ordered.csv", lines, System.Text.Encoding.Unicode);
            }
        }
    }
}
