using System;

namespace Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        
        public FoodItem foodItem { get; set; }

        public int AmountInGram { get; set; }

        public double Protein => foodItem.Protein * AmountInGram / 100.0;

        public double Carbs => foodItem.Carbs * AmountInGram / 100.0;

        public double Fat => foodItem.Fat * AmountInGram / 100.0;
    }
}