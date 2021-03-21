using System;
using System.Collections.Generic;

namespace RKalkyl.Domain
{
    public class FoodItem
    {
        static int staticCount;
        int counter;
        public Guid FoodItemId { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        
        public string Name { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }

        public FoodItem()
        {
            staticCount++;
            counter = staticCount;
        }
    }
}