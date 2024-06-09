using TutorMe.Core.Entities;

namespace TutorMe.Core.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<Guid> GetIdByEmailAsync(string email);
    Task<User?> SelectAsync(Guid id);
}