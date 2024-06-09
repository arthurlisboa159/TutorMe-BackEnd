using TutorMe.Core.Entities;

namespace TutorMe.Core.Repositories;

public interface IPostRepository 
{
    Task AddAsync(Post post);
    Task<List<Post>?> GetPaginatedAsync(int limit, int page, string subjectGroupName);

    Task<List<PostComment>> GetComments(Guid postId);

    Task<Guid> AddComment(PostComment postComment);
}