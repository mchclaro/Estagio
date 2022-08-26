using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Estimate.Commands
{
    public class CreateEstimate
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public string Service { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ValidateDate { get; set; }
            public int ClientId { get; set; }
        }

        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IEstimateRepository _estimateRepository;
            private readonly IClientRepository _clientRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IEstimateRepository estimateRepository,
                            IClientRepository clientRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _estimateRepository = estimateRepository;
                _clientRepository = clientRepository;
                _configuration = configuration;
                _mapper = mapper;
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    var existsClient = await _clientRepository.Exists(request.ClientId);
                    if (!existsClient)
                    {
                        string invalidMedicMessage = "Cliente não está registrado";
                        result.AddError(Code.BadRequest, invalidMedicMessage);
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.Service))
                    {
                        result.AddError(Code.BadRequest, "O nome do servico não pode ser vazio.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.Description))
                    {
                        result.AddError(Code.BadRequest, "A descrição não pode ser vazio.");
                        return result.GetResult();
                    }
                
                    var entity = _mapper.Map<Command, Domain.Entities.Estimate>(request);
                    await _estimateRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao cadastrar o orçamento");
                }

                return result.GetResult();
            }
        }
    }
}