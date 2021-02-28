using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Recepies;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RecepiesController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Recepie>>> GetRecepies()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recepie>> GetRecepie(Guid id)
        {
            return await Mediator.Send(new Details.Query() {Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecepie(Recepie recepie)
        {
            return Ok( await Mediator.Send(new Create.Command(){Recepie = recepie}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecepie(Guid id, Recepie recepie)
        {
            recepie.Id = id;
            return Ok( await Mediator.Send(new Edit.Command(){Recepie = recepie}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepie(Guid id)
        { 
            return Ok(await Mediator.Send(new Delete.Command(){Id = id}));
        }
    }
}