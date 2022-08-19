using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.User;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.User.Queries
{
    public class DetailsUser
    {
        public class Query : IRequest<StandardResult<ListUserDTO>>
        {
            public int Id { get; set; }
        }
        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query,StandardResult<ListUserDTO>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public Handler(IUserRepository userRepository,
                IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<ListUserDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<ListUserDTO>();

                var user = await _userRepository.Read(request.Id);

                if (user == null)
                {
                    result.AddError(Code.NotFound,"Nenhum usuario encontrado para o Id informado.");
                    return result.GetResult();
                }

                var dto = _mapper.Map<Domain.Entities.User, ListUserDTO>(user);

                result.AddData(dto);

                return result.GetResult();
            }
        }
    }
}