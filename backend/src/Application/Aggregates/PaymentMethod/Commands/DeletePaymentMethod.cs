using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.PaymentMethod.Commands
{
    public class DeletePaymentMethod
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IPaymentMethodRepository paymentMethodRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                if (!await _paymentMethodRepository.Exists(request.Id))
                {
                    result.AddError(Code.BadRequest, "Metodo de pagamento não encontrado.");
                    return result.GetResult();
                }

                await _paymentMethodRepository.Delete(request.Id);
                return result.GetResult();
            }
        }
    }
}