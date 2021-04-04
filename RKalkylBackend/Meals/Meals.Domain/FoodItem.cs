using System;
using System.Collections.Generic;
using System.Text;

namespace Meals.Domain
{
    public class FoodItem
    {
        static int staticCount;
        int counter;
        public Guid FoodItemId { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public int WeightPerItem { get; set; }

        public int WeightPerDl { get; set; }

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
