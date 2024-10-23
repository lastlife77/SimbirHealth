using Account.Domain.Contracts;
using Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Persistence;

public class Repository : IRepository
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<User> users;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        users = appDbContext.Users;
    }

    public async Task<User> GetAsync(string username)
    {
        return await users.Where(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task<bool> IsExistAsync(string username)
    {
        return await users.AnyAsync(u => u.Username == username);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await users.ToListAsync();
    }

    public async Task<int> CreateAsync(User user)
    {
        await users.AddAsync(user);
        await appDbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task UpdateAsync(User user)
    {
        users.Update(user);
        await appDbContext.SaveChangesAsync();
    }
}
