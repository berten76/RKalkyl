using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Application.Dtos
{
    public class MealDto
    {
        public Guid MealId { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
