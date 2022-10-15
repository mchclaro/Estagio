using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using Domain.Interfaces.Repositories;
using Domain.Utils;
using FluentValidation;
using MediatR;

namespace Application.Aggregates.User.Commands
{
    public class ChangePassword
    {
        public class Command : IRequest<StandardResult<object>>
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string CurrentPassword { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Senha atual é obrigatória.");
                RuleFor(x => x.CurrentPassword).MinimumLength(8).WithMessage("Senha atual deve possuir pelo menos 8 caracteres");
                RuleFor(x => x.Password).NotEmpty().WithMessage("Nova Senha é obrigatória.");
                RuleFor(x => x.Password).MinimumLength(8).WithMessage("Nova Senha deve possuir pelo menos 8 caracteres");
            }
        }

        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IUserRepository _userRepository;
            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object>{};                
                var user = await _userRepository.Login(request.Email);

                if (user == null || !user.IsActive) {
                    result.AddError(Code.NotAuthorized,"O usuário/senha digitado não é válido");
                    return result.GetResult();
                }

                var isCorrectPassword = Crypto.ComparePasswords(request.CurrentPassword, user.Password);
                if (!isCorrectPassword) {
                    result.AddError(Code.NotAuthorized,"O usuário/senha digitado não é válido");
                    return result.GetResult();
                }

                await _userRepository.ChangePassword(request.Email, request.Password);
                return result.GetResult();
            }
        }
    }
}