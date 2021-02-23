using System;

namespace Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }
    }
}