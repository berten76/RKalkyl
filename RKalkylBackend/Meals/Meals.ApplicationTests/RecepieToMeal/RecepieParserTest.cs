using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Application.RecepieToMeal;
using NUnit.Framework;

namespace Meals.ApplicationTests.RecepieToMeal
{
    [TestFixture]
    public class RecepieParserTest
    {
        [TestCase("1 1/2 dl grovhackade rostade pumpafrö", 1.5, "dl", "grovhackade rostade pumpafrö")]
        [TestCase("salt och peppar", 0, "st", "salt och peppar")]
        [TestCase("1 tsk torkad timjan", 1, "tsk", "torkad timjan")]
        [TestCase("4 kycklingfiléer", 4, "st", "kycklingfiléer")]
        [TestCase("1 msk vetemjöl", 1, "msk", "vetemjöl")]
        [TestCase("500 g tomater, finkrossade eller passerade", 500, "g", "tomater, finkrossade eller passerade")]
        public void Parse_Recepie_returnsMeal(string recepieLine, double amount, string unit, string ingredient)
        {
            var parser = new RecepieParser();
            var parsedData = parser.ParseLine(recepieLine);

            Assert.AreEqual(amount, parsedData.Amount);
            Assert.AreEqual(unit, parsedData.Unit);
            Assert.AreEqual(ingredient, parsedData.IngredientString);
        }
    }
}
