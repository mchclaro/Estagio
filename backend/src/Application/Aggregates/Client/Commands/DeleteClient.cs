using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;

namespace Application.Aggregates.Client.Commands
{
    public class DeleteClient
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            
            private readonly IClientRepository _clientRepository;
            private readonly IFileStorageService _fileStorage;
            private readonly IMapper _mapper;

            public Handler(IClientRepository clientRepository, IFileStorageService fileStorage, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _fileStorage = fileStorage;
                _mapper = mapper;
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                if (!await _clientRepository.Exists(request.Id))
                {
                    result.AddError(Code.NotFound, "Não foi possível deletar, pois o Cliente não foi encontrado.");
                    return result.GetResult();
                }

                var client = await _clientRepository.Read(request.Id);

                await _fileStorage.DeleteFileFromUrl(client.PhotoUrl);

                await _clientRepository.Delete(request.Id);
                
                result.AddError(Code.Ok, "Cliente excluído com sucesso.");

                return result.GetResult();
            }
        }
    }
}