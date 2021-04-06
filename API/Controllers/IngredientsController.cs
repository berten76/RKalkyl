using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RKalkyl.Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Ingredients;

namespace API.Controllers
{
    public class IngredientsController : BaseApiController
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(Guid id, Ingredient ingredient)
        {
            ingredient.Id = id;
           
       
            return Ok( await Mediator.Send(new Edit.Command(){Ingredient = ingredient}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(IngredientDto ingredient)
        {

            return Ok( await Mediator.Send(new Create.Command(){Ingredient = ingredient}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        { 
            return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}