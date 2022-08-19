using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Client;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.Client.Queries
{
    public class ListClient
    {
        public class Query : IRequest<StandardResult<List<ListClientDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListClientDTO>>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;

            public Handler(IClientRepository clientRepository,
                IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListClientDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListClientDTO>> { };

                var clientList = await _clientRepository.ReadAll();

                var responseData = clientList.Select(x => _mapper.Map<Domain.Entities.Client, ListClientDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}