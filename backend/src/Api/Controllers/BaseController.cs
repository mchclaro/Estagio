using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Application.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => 
            _mediator ?? 
            (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        [NonAction]
        protected IActionResult GetIActionResult<T>(StandardResult<T> result)
        {
            if (result == null)
                return StatusCode((int)HttpStatusCode.InternalServerError, null);
            return StatusCode((int)result.StatusCode, result.Body);
        }
    }
}