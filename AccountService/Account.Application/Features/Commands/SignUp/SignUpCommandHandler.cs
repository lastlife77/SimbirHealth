using Account.Application.Dtos;
using Account.Application.ErrorHandling;
using Account.Doamin;
using MediatR;

namespace Account.Application.Features.Commands.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result>
{
    private readonly UserManager userManager;

    public SignUpCommandHandler(UserManager userManager)
    {
        this.userManager = userManager;
    }

    public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        SignUpDto signUp = request.SignUp;
        try
        {
            await userManager.SignUp(signUp.UserName, signUp.LastName, signUp.UserName, signUp.Password);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }

        return Result.Ok("Регистрация прошла успешно");
    }
}