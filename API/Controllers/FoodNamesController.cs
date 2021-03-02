using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RKalkyl.Application.FoodItems;
using RKalkyl.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    public class FoodNamesController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetFoodNames()
        {
            var foodItem = await Mediator.Send(new List.Query());
            var foodNames = foodItem.Select(f => f.Name).ToList();
            return foodNames;
        }
    }
}