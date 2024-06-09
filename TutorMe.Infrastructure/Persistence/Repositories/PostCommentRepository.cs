using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;

namespace TutorMe.Infrastructure.Persistence.Repositories;

public class PostCommentRepository : IPostCommentRepository
{
    private readonly TutorMeDbContext _dbContext;

    public PostCommentRepository(TutorMeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(PostComment comment)
    {
        await _dbContext.PostComments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }
}