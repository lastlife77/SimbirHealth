using Account.Doamin.Contracts;
using Account.Domain;
using Account.Domain.Contracts;
using Account.Domain.Entities;
using System.Linq.Expressions;

namespace Account.Doamin;

public class UserManager
{
    private readonly IPasswordHasher passwordHasher;
    private readonly IRepository repository;
    private readonly IJwtProvider jwtProvider;

    public UserManager(IPasswordHasher passwordHasher, IRepository repository, IJwtProvider jwtProvider)
    {
        this.passwordHasher = passwordHasher;
        this.repository = repository;
        this.jwtProvider = jwtProvider;
    }

    public async Task SignUp(
        string lastname, 
        string firstname, 
        string username, 
        string password)
    {
        string passwordHash = passwordHasher.Generate(password);

        User user = User.Create(lastname, firstname, username, passwordHash).AddRole(Role.User);
        try
        {
            await repository.CreateAsync(user);
        }
        catch (Exception ex)
        {
            throw new Exception("500: Внутренняя ошибка сервера");
        }
    }

    public async Task<string> SignIn(string username, string password)
    {
        bool isExist = await repository.IsExistAsync(username);

        if (!isExist)
        {
            throw new Exception("Неверный логин или пароль");
        }

        User user;
        try
        {
            user = await repository.GetAsync(username);
        }
        catch(Exception ex)
        {
            throw new Exception($"500: Внутренняя ошибка сервера");
        }

        bool passwordIsRight = passwordHasher.Verify(password, user.PasswordHash);

        if (!passwordIsRight) 
        {
            throw new Exception("Неверный логин или пароль");
        }

        return jwtProvider.GenerateToken(user);
    } 
}