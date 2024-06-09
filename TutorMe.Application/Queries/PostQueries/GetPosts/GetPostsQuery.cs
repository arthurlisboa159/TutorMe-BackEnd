using MediatR;
using TutorMe.Core.Entities;

namespace TutorMe.Application.Queries.PostQueries.GetPosts;

public class GetPostsQuery : IRequest<List<Post>>
{
    public int limit { get; set; }
    public int page { get; set; }
    public string subjectGroupName { get; set; }
}