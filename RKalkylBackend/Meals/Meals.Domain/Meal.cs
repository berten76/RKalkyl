using System;
using System.Collections.Generic;
using System.Text;

namespace Meals.Domain
{
    public class Meal
    {
        public Guid MealId { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
