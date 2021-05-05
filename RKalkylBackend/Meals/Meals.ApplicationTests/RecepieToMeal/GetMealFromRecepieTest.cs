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
        [TestCase("1 1/2 dl grovhackade rostade pumpafrö", "Pumpafrö", 20)]
        //[TestCase("2 förp kokta svarta bönor(à 380 g)","", 760)]
        //[TestCase("2 dl havregryn", "havregryn fullkorn", 80)]
        //[TestCase("1 st banan(stor)", "Banan", 120)]
        //[TestCase("2 krm vaniljsocker", "socker", 2)]
        //[TestCase("4 kycklingfiléer", "Kyckling bröst filé rå u. skinn", 660)]
        //[TestCase("0.5 st Gul lök", "Lök gul", 50)]
        //[TestCase("1/4 gul lök", "Lök gul", 25)]

        public void GetMealWithCandidatesTest(string recepie, string expectedFood, int expectedAmountInGram)
        {
            var foodItems = Seed.ReadFoodItems();
            var result = GetMealFromRecepie.GetMealWithCandidates(new List<string> { recepie }, foodItems);


            Assert.AreEqual(expectedFood.ToLower(), result.Ingredients[0].Candidates[0].foodItem.Name.ToLower());
            Assert.AreEqual(expectedAmountInGram, result.Ingredients[0].Candidates[0].AmountInGram);
        }
    }
}
