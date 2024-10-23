using System.Collections.Generic;

namespace Account.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Lastname { get; set; }

    public string Firstname { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public List<Role> Roles { get; set; } = [];

    public static User Create(string lastname, string firstname, string username, string passwordHash)
    {
        return new User
        {
            Lastname = lastname,
            Firstname = firstname,
            Username = username,
            PasswordHash = passwordHash,
        };
    }
}
