using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Client.Commands;
using Application.Aggregates.Client.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        /// <summary>
        /// Cria um cliente
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateClient.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateClient.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos clientes
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListClient.Query { }));
        }

        /// <summary>
        /// Busca um cliente por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsClient.Query { Id = id }));
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClient.Command { Id = id };
            return GetIActionResult(await Mediator.Send(command));
        }
    }
}