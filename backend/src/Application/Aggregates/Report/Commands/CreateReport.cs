using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Report.Commands
{
    public class CreateReport
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Type { get; set; }
            public int AppointmentId { get; set; }
            public int AppointmentPaymentId { get; set; }
        }
        
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IReportsRepository _reportRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IReportsRepository reportRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _reportRepository = reportRepository;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    if (request.Type == 0)
                    {
                        result.AddError(Code.BadRequest, "Informe um tipo de relatório.");
                        return result.GetResult();
                    }
                
                    var entity = _mapper.Map<Command, Domain.Entities.Report>(request);
                    await _reportRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao emitir o relatório.");
                }

                return result.GetResult();
            }
        }
    }
}