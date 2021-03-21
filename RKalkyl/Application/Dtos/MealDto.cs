using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class MealDto
    {
        public Guid MealId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}