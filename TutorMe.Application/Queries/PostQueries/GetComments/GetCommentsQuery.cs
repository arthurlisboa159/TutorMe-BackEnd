using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Queries.PostQueries.GetComments;

public class GetCommentsQuery : IRequest<List<PostCommentViewModel>?>
{
    public Guid Id { get; set; }

    public GetCommentsQuery(Guid id)
    {
        Id = id;
    }
}