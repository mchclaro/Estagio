using System.Threading.Tasks;
using backend.src.Application.Aggregates.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Aggregates.User.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {   
        /// <summary>
        /// Cria um usuario
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateUser.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateUser.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos usuarios
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListUser.Query { }));
        }

        /// <summary>
        /// Busca um usuario por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsUser.Query { Id = id }));
        }
    }
}