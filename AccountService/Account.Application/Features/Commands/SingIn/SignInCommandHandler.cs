using Account.Application.Dtos;
using Account.Application.ErrorHandling;
using Account.Doamin;
using MediatR;

namespace Account.Application.Features.Commands.SingIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Result<string>>
{
    private readonly UserManager userManager;

    public SignInCommandHandler(UserManager userManager)
    {
        this.userManager = userManager;
    }

    public async Task<Result<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        SignInDto signIn = request.SignIn;
        string token;

        try
        {
            token = await userManager.SignIn(signIn.UserName, signIn.Password);
        }
        catch (Exception ex)
        {
            return Result.Fail<string>(ex.Message);
        }

        return Result.Ok<string>(token);
    }
}