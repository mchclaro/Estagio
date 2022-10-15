using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.DTO.User;
using Domain.Interfaces.Repositories;
using Domain.Utils;
using MediatR;

namespace Application.Aggregates.User.Queries
{
    public class LoginUser
    {
        public class Query : IRequest<StandardResult<ListUserDTO>>
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Query, StandardResult<ListUserDTO>>
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
                var result = new StandardResult<ListUserDTO>{};

                var user = await _userRepository.Login(request.Email);

                var notFoundMessage = "O usuário/senha digitado não é válido. Tente novamente ou resete sua senha";

                if (user is null || !user.IsActive) {
                    result.AddError(Code.NotFound,notFoundMessage);
                    return result.GetResult();
                }

                var isCorrectEmail = user.Email == request.Email;
                if (!isCorrectEmail) {
                    result.AddError(Code.NotFound,notFoundMessage);
                    return result.GetResult();
                }

                var isCorrectPassword = Crypto.ComparePasswords(request.Password, user.Password);
                if (!isCorrectPassword) {
                    result.AddError(Code.NotFound,notFoundMessage);
                    return result.GetResult();
                }

                var responseData = _mapper.Map<Domain.Entities.User,ListUserDTO>(user);
                result.AddData(responseData);
                return result.GetResult();
            }
        }
    }
}