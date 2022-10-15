using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        /// <summary>
        /// Autentica o login
        /// </summary>
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUser.Query query)
        {
            return GetIActionResult(await Mediator.Send(query));
        }
    }
}