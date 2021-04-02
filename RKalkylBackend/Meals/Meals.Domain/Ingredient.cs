using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meals.Domain
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public Guid FoodItemId { get; set; }
        public FoodItem foodItem { get; set; }

        public int AmountInGram { get; set; }
    }
}
