using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.PaymentMethod.Commands;
using Application.Aggregates.PaymentMethod.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentMethodController : BaseController
    {
        /// <summary>
        /// Cria um metodo de pagamento
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentMethod.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }
        
        /// <summary>
        /// Atualiza um metodo de pagamento
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentMethod.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Exclui um metodo de pagamento
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePaymentMethod.Command { Id = id };
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos métodos de pagamento
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListPaymentMethod.Query { }));
        }

        /// <summary>
        /// Busca um  métodos de pagamento por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsPaymentMethod.Query { Id = id }));
        }
    }
}