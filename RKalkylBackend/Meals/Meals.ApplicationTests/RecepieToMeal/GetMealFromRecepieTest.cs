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
    public class GetMealFromRecepieTest
    {

        [TestCase("4 kycklingfiléer", "Kyckling bröst filé rå u. skinn", 660)]
        [TestCase("0.5 st Gul lök", "Lök gul", 50)]
        public void GetMealWithCandidatesTest(string recepie, string expectedFood, int expectedAmountInGram)
        {
            var foodItems = Seed.ReadFoodItems();
            var result = GetMealFromRecepie.GetMealWithCandidates(new List<string> { recepie }, foodItems);


            Assert.AreEqual(expectedFood, result.Ingredients[0].Candidates[0].foodItem.Name);
            Assert.AreEqual(expectedAmountInGram, result.Ingredients[0].Candidates[0].AmountInGram);
        }
    }
}
