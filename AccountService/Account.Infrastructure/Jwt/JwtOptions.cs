namespace Account.Infrastructure.Jwt;

public class JwtOptions
{
    public const string SectionName = "DefaultSettings:Jwt";

    public string SecretKey { get; set; } = string.Empty;

    public int ExpiresHours { get; set; }
}
