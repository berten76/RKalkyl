using System;
using System.ComponentModel.DataAnnotations;

namespace RKalkyl.Domain
{
    public class Ingredient
    {
                static int staticCounter;
        int counter;

        [Key]
        public Guid Id { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public Guid FoodItemId { get; set; }
        public FoodItem foodItem { get; set; }

        public int AmountInGram { get; set; }

        public double Protein => foodItem.Protein * AmountInGram / 100.0;

        public double Carbs => foodItem.Carbs * AmountInGram / 100.0;

        public double Fat => foodItem.Fat * AmountInGram / 100.0;

        public Ingredient()
        {
            counter = staticCounter++;
        }
    }
}