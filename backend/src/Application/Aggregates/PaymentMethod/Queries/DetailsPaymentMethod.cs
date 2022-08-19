using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.PaymentMethod;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.PaymentMethod.Queries
{
    public class DetailsPaymentMethod
    {
        public class Query : IRequest<StandardResult<ListPaymentMethodDTO>>
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query,StandardResult<ListPaymentMethodDTO>>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public Handler(IPaymentMethodRepository paymentMethodRepository,
                IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListPaymentMethodDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListPaymentMethodDTO>();

                var paymentMethod = await _paymentMethodRepository.Read(request.Id);

                if (paymentMethod == null)
                {
                    result.AddError(Code.NotFound,"Nenhum método de pagamento encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.PaymentMethod, ListPaymentMethodDTO>(paymentMethod);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}