using Account.Domain.Contracts;
using Account.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.Infrastructure.Jwt;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        this.options = options.Value;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims = [new Claim("userId", user.Id.ToString()), new Claim("username", user.Username)];

        SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
            SecurityAlgorithms.HmacSha256
            );

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(options.ExpiresHours)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
