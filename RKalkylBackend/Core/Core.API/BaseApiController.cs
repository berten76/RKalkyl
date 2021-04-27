//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Core.Application;

namespace Core.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator;
        public BaseApiController()
        {
        }

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess) return Ok(result.Value);
            if (result.ResultType == Result<T>.resultType.NotFound) return NotFound();
            return BadRequest(result.Error);
        }
    }
}
