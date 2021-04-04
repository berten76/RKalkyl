using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Application.RecepieToMeal;
using Meals.Persistence;
using NUnit.Framework;

namespace Meals.ApplicationTests.RecepieToMeal
{
    [TestFixture]
    public class FoodItemFinderTest
    {
        [TestCase("vetemjöl", "vetemjöl")]
        [TestCase("kycklingfiléer", "Kyckling bröst filé rå u. skinn")]
        [TestCase("500 g tomater, finkrossade eller passerade", "Tomat krossad konserv. m. lag")]
        [TestCase("2 tsk senap, finkornig", "Senap fransk")]
        [TestCase("600 g blandfärs", "Blandfärs rå nöt 70% gris 30%")]
        [TestCase("0,5 dl chilisås", "Chilisås tomat")]
        [TestCase("kycklingfilé(er)", "Kyckling bröst filé rå u. skinn")]
        [TestCase("potatis(ar)", "Potatis rå")]
        public void FoodItemFinder_returnsCorrectFoodItem(string foodIn, string expected)
        {
            var foodItems = Seed.ReadFoodItems();

            var foodItemFinder = new FoodItemFinder();

            var foodItemsCandidates = foodItemFinder.FindFood(foodIn, foodItems);

            Assert.AreEqual(expected.ToLower(), foodItemsCandidates[0].Name.ToLower());
        }
    }
}
