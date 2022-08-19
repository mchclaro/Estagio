using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.User;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Aggregates.User.Queries
{
    public class ListUser
    {
        public class Query : IRequest<StandardResult<List<ListUserDTO>>>
        {
            
        }
        public class Handler : IRequestHandler<Query, StandardResult<List<ListUserDTO>>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public Handler(IUserRepository userRepository,
                IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<StandardResult<List<ListUserDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<List<ListUserDTO>> { };

                var userList = await _userRepository.ReadAll();

                var responseData = userList.Select(x => _mapper.Map<Domain.Entities.User, ListUserDTO>(x)).ToList();

                result.AddData(responseData);

                return result.GetResult();
            }
        }
    }
}