using Account.Application.Dtos;
using Account.Application.ErrorHandling;
using MediatR;

namespace Account.Application.Features.Commands.SingIn;

public class SignInCommand : IRequest<Result<string>>
{
    public SignInDto SignIn { get; set; }
}