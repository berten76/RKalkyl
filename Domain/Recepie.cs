using System;
using System.Collections.Generic;

namespace Domain
{
    public class Recepie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<FoodItem> FoodItems { get; set; }
}
}