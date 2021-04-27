using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meals.Domain;
using Meals.Application.FoodItems;
using MediatR;
using Core.API;

namespace Meals.API
{
    public class FoodItemsController : BaseApiController
    {
        public FoodItemsController(IMediator mediator):base(mediator)
        {

        }

        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> GetFoodItems()
        {
            try
            {
                return await Mediator.Send(new List.Query());
            }
            catch(Exception e)
            {

            }
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(Guid id)
        {
            return await Mediator.Send(new Details.Query() { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodItem(FoodItem foodItem)
        {
            return Ok(await Mediator.Send(new Create.Command() { FoodItem = foodItem }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodItem(Guid id, FoodItem foodItem)
        {
            foodItem.FoodItemId = id;
            return Ok(await Mediator.Send(new Edit.Command() { FoodItem = foodItem }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command() { Id = id }));
        }
    }
}
