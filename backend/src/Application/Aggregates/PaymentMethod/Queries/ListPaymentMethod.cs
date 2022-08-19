using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.PaymentMethod;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.PaymentMethod.Queries
{
    public class ListPaymentMethod
    {
        public class Query : IRequest<StandardResult<List<ListPaymentMethodDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListPaymentMethodDTO>>>
        {
            private readonly IPaymentMethodRepository _paymentMethodRepository;
            private readonly IMapper _mapper;

            public Handler(IPaymentMethodRepository paymentMethodRepository,
                IMapper mapper)
            {
                _paymentMethodRepository = paymentMethodRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListPaymentMethodDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListPaymentMethodDTO>> { };

                var paymentMethodList = await _paymentMethodRepository.ReadAll();

                var responseData = paymentMethodList.Select(x => _mapper.Map<Domain.Entities.PaymentMethod, ListPaymentMethodDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}