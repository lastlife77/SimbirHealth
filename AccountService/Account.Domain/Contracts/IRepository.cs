using Account.Domain.Entities;
using System;

namespace Account.Domain.Contracts;

public interface IRepository
{
    Task<User> GetAsync(string username);

    Task<List<User>> GetAllAsync();

    Task<bool> IsExistAsync(string username);

    Task<int> CreateAsync(User user);

    Task UpdateAsync(User user);
}
