using System;
using System.Collections.Generic;

namespace RKalkyl.Domain
{
    public class Meal
    {
        static int staticCounter;
        int counter;
        public Guid MealId { get; set; }
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public Meal()
        {
counter = staticCounter++;
        }
}
}