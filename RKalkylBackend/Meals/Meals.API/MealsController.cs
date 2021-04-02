//using System;
//using System.Collections.Generic;
//using System.Text;
using Controllers;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Meals.API
{
    [ApiController]
    [Route("[controller]")]
    public class MealsController : BaseApiController
    {
        public MealsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public ActionResult<string> GetMeals()
        {
            return "Meal";
        }
    }
}