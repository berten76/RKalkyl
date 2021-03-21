using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RKalkyl.Application.Meals;

using RKalkyl.Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;

namespace API.Controllers
{
    public class MealsController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<MealDto>>> GetMeals()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealDto>> GetMeal(Guid id)
        {
            return await Mediator.Send(new Details.Query() {Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(Meal meal)
        {
            return Ok( await Mediator.Send(new Create.Command(){Meal = meal}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(Guid id, Meal meal)
        {
            meal.MealId = id;
           
            return Ok( await Mediator.Send(new Edit.Command(){Meal = meal}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        { 
            return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}