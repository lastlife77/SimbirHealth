using Account.Application.Dtos;
using Account.Application.ErrorHandling;
using MediatR;

namespace Account.Application.Features.Commands.SignUp;

public class SignUpCommand : IRequest<Result>
{
    public SignUpDto SignUp { get; set; }
}