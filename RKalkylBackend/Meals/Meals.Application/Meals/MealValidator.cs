using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Meals.Domain;

namespace Meals.Application.Meals
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Ingredients).NotEmpty();
        }
    }
}
