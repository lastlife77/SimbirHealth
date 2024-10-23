using Account.Domain.Entities;

namespace Account.Domain;

public static class UserExtensions
{
    public static User Update(this User user, string lastname, string firstname, string passwordHash) 
    { 
        user.Lastname = lastname;
        user.Firstname = firstname;
        user.PasswordHash = passwordHash;

        return user;
    }

    public static User AddRole(this User user, Role role)
    {
        user.Roles.Add(role);

        return user;
    }
}
