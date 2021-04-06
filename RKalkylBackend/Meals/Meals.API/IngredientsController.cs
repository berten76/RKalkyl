using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Meals.Application.FoodItems;
using Meals.Domain;
using Microsoft.AspNetCore.Mvc;
using Meals.Application.Ingredients;
using Meals.Application.Dtos;
using MediatR;
using Controllers;

namespace Meals.API
{
    public class IngredientsController : BaseApiController
    {
        public IngredientsController(IMediator mediator) :base(mediator)
        {

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(Guid id, Ingredient ingredient)
        {
            ingredient.Id = id;


            return Ok(await Mediator.Send(new Edit.Command() { Ingredient = ingredient }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(IngredientDto ingredient)
        {

            return Ok(await Mediator.Send(new Create.Command() { Ingredient = ingredient }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command() { Id = id }));
        }
    }
}
