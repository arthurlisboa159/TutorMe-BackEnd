using Microsoft.EntityFrameworkCore;
using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;

namespace TutorMe.Infrastructure.Persistence.Repositories;

public class PostRepository : IPostRepository
{
    private readonly TutorMeDbContext _dbContext;

    public PostRepository(TutorMeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Post>?> GetPaginatedAsync(int limit, int page, string subjectGroupName)
    {
        var query = _dbContext.Posts
            .AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.PostLikes)
            .AsSingleQuery()
            .Where(p => p.SubjectGroup.Name.Equals(subjectGroupName))
            .OrderByDescending(p => p.CreatedAt);

        return await query
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<List<PostComment>> GetComments(Guid postId)
    {
        var query = await _dbContext.
            PostComments.Where(p =>  p.PostId == postId)
            .Include(p => p.User)
            .ToListAsync();

        return query;
    }

    public async Task<Guid> AddComment(PostComment postComment)
    {
        await _dbContext.PostComments.AddAsync(postComment);
        await _dbContext.SaveChangesAsync();

        return postComment.Id;
    }

    public async Task AddAsync(Post post)
    {
        await _dbContext.Posts.AddAsync(post);
        await _dbContext.SaveChangesAsync();
    }
    
    // public async Task Update(Post post)
    // {
    //     _dbContext.Update(post);
    //     await _dbContext.SaveChangesAsync();
    // }
    //
    // public async Task RemoveAsync(Post post)
    // {
    //     _dbContext.Posts.Remove(post);
    //     await _dbContext.SaveChangesAsync();
    // }
    //
}