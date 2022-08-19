using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.Client;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.Client.Queries
{
    public class DetailsClient
    {
        public class Query : IRequest<StandardResult<ListClientDTO>>
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query,StandardResult<ListClientDTO>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;

            public Handler(IClientRepository clientRepository,
                IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListClientDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListClientDTO>();

                var client = await _clientRepository.Read(request.Id);

                if (client == null)
                {
                    result.AddError(Code.NotFound,"Nenhum cliente encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.Client, ListClientDTO>(client);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}