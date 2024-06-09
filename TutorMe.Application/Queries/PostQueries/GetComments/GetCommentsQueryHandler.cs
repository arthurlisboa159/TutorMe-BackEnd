using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Queries.PostQueries.GetComments;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<PostCommentViewModel>?>
{
    private readonly IPostRepository _postRepository;

    public GetCommentsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<PostCommentViewModel>?> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _postRepository.GetComments(request.Id);

        var commentsList = new List<PostCommentViewModel>();
        
        foreach (var comment in comments)
        {
            commentsList.Add(new PostCommentViewModel(
                comment.Id, 
                comment.Text, 
                comment.UserId, 
                comment.PostId,
                comment.User.FullName,
                comment.CreatedAt,
                comment.User.IsTutor)
            );
        }

        return commentsList;
    }
}