using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using MediatR;
using Meals.Domain;
using Meals.Application.Meals;
using Meals.Application.Dtos;
using Core.API;

namespace Meals.API
{

    public class MealsController : BaseApiController
    {
        public MealsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<ActionResult<List<MealDto>>> GetMeals()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealDto>> GetMeal(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(Meal meal)
        {
            return HandleResult(await Mediator.Send(new Create.Command() { Meal = meal }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(Guid id, Meal meal)
        {
            meal.MealId = id;

            return HandleResult(await Mediator.Send(new Edit.Command() { Meal = meal }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() { Id = id }));
        }
    }
}