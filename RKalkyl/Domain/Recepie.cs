using System;
using System.Collections.Generic;

namespace RKalkyl.Domain
{
    public class Recepie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
}
}