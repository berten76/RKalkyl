using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Application.Dtos
{
    public class FoodItemDto
    {
        public Guid FoodItemId { get; set; }

        public string Name { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }
    }
}
