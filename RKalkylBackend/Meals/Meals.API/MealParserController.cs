using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.API;
using Meals.Application.RecepieToMeal;
using Meals.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Meals.API
{
    public class Recepie
    {
        public string res { get; set; }
    }


    public class MealParserController : BaseApiController
    {
        public MealParserController(IMediator mediator) : base(mediator)
        {

        }

        //[HttpGet("{recepie}")]
        //public ActionResult<int> GetMeals(string recepie)
        //{
        //    var tmp = recepie.Split(';');
        //    return 34;
        //}
        //[HttpPut("{ggg}")]
        //public ActionResult<int> GetMeals(string ggg, string recepie)
        //{
        //    return 34;
        //}
        [HttpPost("{mealId}")]
        public async Task<ActionResult<List<Ingredient>>> GetMeals(Guid mealId, Recepie recepie)
        {
            var ingredients = await Mediator.Send(new GetMealFromRecepie.Query()
            {
                Recepie = recepie.res,
                MealId = mealId
            });

            foreach (var ingredient in ingredients)
            {
                await Mediator.Send(new Meals.Application.Ingredients.Create.Command() { Ingredient = ingredient });
            }
            return Ok(ingredients);
        }
    }
}
