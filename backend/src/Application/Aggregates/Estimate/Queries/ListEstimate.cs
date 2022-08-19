using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Estimate;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Estimate.Queries
{
    public class ListEstimate
    {
        public class Query : IRequest<StandardResult<List<ListEstimateDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListEstimateDTO>>>
        {
            private readonly IEstimateRepository _estimateRepository;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;

            public Handler(IEstimateRepository estimateRepository,
                           IConfiguration configuration,
                           IMapper mapper)
            {
                _estimateRepository = estimateRepository;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListEstimateDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListEstimateDTO>> { };

                var estimateList = await _estimateRepository.ReadAll();

                var responseData = estimateList.Select(x => _mapper.Map<Domain.Entities.Estimate, ListEstimateDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}