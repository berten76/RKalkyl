using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Application.RecepieToMeal.Models;
using Meals.Domain;

namespace Meals.Application.RecepieToMeal
{
    public class FoodItemFinder
    {
        public List<FoodItem> FindFood(string foodIn, List<FoodItem> foodItems)
        {
            foodIn = foodIn.ToLower();
            List<FoodItemCandidate> candidates = new List<FoodItemCandidate>();

            foreach (var foddItem in foodItems)
            {
                var foodItemSplit = foddItem.Name.Split(" ");
                if (foodIn.Contains(foodItemSplit[0].ToLower()))
                {
                    candidates.Add(new FoodItemCandidate()
                    {
                        FoodItem = foddItem,
                        CandidatValue = 1
                    });
                }
            }

         //   var length = candidates.Max(c => c.FoodItem.Name.Split(" ")[0].Length);

           // candidates = candidates.Where(c => c.FoodItem.Name.Split(" ")[0].Length >= length - 1).ToList();

            if (candidates.Count == 1)
            {
                return candidates.Select(c => c.FoodItem).ToList();
            }


            foreach (var candidate in candidates)
            {
                var foodItemSplits = candidate.FoodItem.Name.Split(" ").ToList();
                for(int i = 0; i < foodItemSplits.Count; i++)
                {
                    if(foodItemSplits[i].Length <= 2 && foodItemSplits[i].ToLower() != "rå")
                    {
                        continue;
                    }
                    if (foodIn.Contains(foodItemSplits[i].ToLower()))
                    {
                        candidate.CandidatValue += foodItemSplits[i].Length;
                    }
                }
            }

            //foreach (var candidate in candidates)
            //{
            //    var foodItemSplits = candidate.FoodItem.Name.Split(" ");
            //    foreach (var foodItemSplit in foodItemSplits)
            //    {
            //        if (foodIn.Contains(foodItemSplit.ToLower()))
            //        {
            //            candidate.CandidatValue += foodItemSplit.Length;
            //        }
            //    }
            //}

            candidates.Sort((a, b) =>
            {
                if (a.CandidatValue == b.CandidatValue)
                {
                    if (a.FoodItem.Name.Length > b.FoodItem.Name.Length) return 1;
                    else return -1;
                }
                if (a.CandidatValue < b.CandidatValue) return 1;
                else return -1;
            });

            if (candidates.Count == 0) return new List<FoodItem>();
            var maxCandidateValue = candidates.Max(c => c.CandidatValue);


            return candidates.Where(c => c.CandidatValue > maxCandidateValue/2).Select(c => c.FoodItem).ToList();
        }
    }
}
