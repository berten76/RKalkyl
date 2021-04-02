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

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        //public BaseApiController()
        //{
        //}

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
