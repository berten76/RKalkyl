using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Domain;

namespace Meals.Application.RecepieToMeal.Models
{
    public class IngredientCandidate
    {
        public Guid FoodItemId { get; set; }
        public FoodItem foodItem { get; set; }

        public int AmountInGram { get; set; }

        public string Unit { get; set; }

        public int AmountInUnit { get; set; }
    }
}
