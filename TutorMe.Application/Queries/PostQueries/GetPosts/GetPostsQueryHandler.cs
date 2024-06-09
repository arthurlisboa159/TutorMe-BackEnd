using MediatR;
using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Queries.PostQueries.GetPosts;

public class GetPostsQueryHandler 
    : IRequestHandler<GetPostsQuery, List<Post>?>
{
    private readonly IPostRepository _postRepository;

    public GetPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<Post>?> Handle(
        GetPostsQuery request, 
        CancellationToken cancellationToken
    )
    {
        return await _postRepository
            .GetPaginatedAsync(
                request.limit, 
                request.page, 
                request.subjectGroupName
            );
    }
}


