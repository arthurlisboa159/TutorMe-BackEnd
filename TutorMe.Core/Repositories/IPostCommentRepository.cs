using TutorMe.Core.Entities;

namespace TutorMe.Core.Repositories;

public interface IPostCommentRepository
{
    Task AddAsync(PostComment comment);
}