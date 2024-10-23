using Account.Domain.Entities;

namespace Account.Domain.Contracts;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
