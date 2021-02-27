using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.FoodItems;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FoodItemsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> GetFoodItems()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(Guid id)
        {
            return await Mediator.Send(new Details.Query() {Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodItem(FoodItem foodItem)
        {
            return Ok( await Mediator.Send(new Create.Command(){FoodItem = foodItem}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodItem(Guid id, FoodItem foodItem)
        {
            foodItem.Id = id;
            return Ok( await Mediator.Send(new Edit.Command(){FoodItem = foodItem}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}