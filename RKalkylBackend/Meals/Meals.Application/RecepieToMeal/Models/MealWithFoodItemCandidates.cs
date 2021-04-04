using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Application.RecepieToMeal.Models
{
    public class MealWithFoodItemCandidates
    {
        public List<IngredientCandidates> Ingredients { get; set; } = new List<IngredientCandidates>();
    }
}
