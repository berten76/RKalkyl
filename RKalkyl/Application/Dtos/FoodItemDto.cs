using System;

namespace Application.Dtos
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