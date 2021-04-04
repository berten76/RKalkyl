using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Application.Dtos
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public FoodItemDto foodItem { get; set; }

        public Guid MealId { get; set; }

        public int AmountInGram { get; set; }

    }
}
