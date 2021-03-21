using System;

namespace Application.Dtos
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public FoodItemDto foodItem { get; set; }

        public Guid MealId { get; set; }

        public int AmountInGram { get; set; }

    }
}