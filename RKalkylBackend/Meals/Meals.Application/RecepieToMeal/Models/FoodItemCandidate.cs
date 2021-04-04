using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Domain;

namespace Meals.Application.RecepieToMeal.Models
{
    public class FoodItemCandidate
    {
        public FoodItem FoodItem { get; set; }
        public int CandidatValue { get; set; }
    }
}
