using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Commands.PostCommands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, AddCommentViewModel>
{

    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public AddCommentCommandHandler(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<AddCommentViewModel> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userRepository.GetIdByEmailAsync(request.UserEmail);
        
        var postComment = new PostComment(
            request.Text, 
            userId, 
            request.PostId
        );

        var id = await _postRepository.AddComment(postComment);

        return new AddCommentViewModel(id);
    }
}