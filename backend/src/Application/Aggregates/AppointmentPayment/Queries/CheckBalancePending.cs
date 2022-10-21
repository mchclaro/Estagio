using Application.Result;
using AutoMapper;
using Domain.DTO.AppointmentPayment;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.AppointmentPayment.Queries
{
    public class CheckBalancePending
    {
        public class Query : IRequest<StandardResult<ListAppointmentPaymentDTO>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<ListAppointmentPaymentDTO>>
        {
            private readonly IAppointmentPaymentRepository _appointmentPaymentRepository;
            private readonly IMapper _mapper;

            public Handler(IAppointmentPaymentRepository appointmentPaymentRepository,
                IMapper mapper)
            {
                _appointmentPaymentRepository = appointmentPaymentRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListAppointmentPaymentDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListAppointmentPaymentDTO> { };

                var pending = await _appointmentPaymentRepository.CheckBalancePending();

                var responseData = _mapper.Map<Domain.Entities.AppointmentPayment, ListAppointmentPaymentDTO>(pending);

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}