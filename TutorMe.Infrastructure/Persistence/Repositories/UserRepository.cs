using Microsoft.EntityFrameworkCore;
using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;

namespace TutorMe.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TutorMeDbContext _dbContext;

    public UserRepository(TutorMeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);

        return user;
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }

    public async Task<Guid> GetIdByEmailAsync(string email)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

        return user!.Id;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> SelectAsync(Guid id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
    }
}