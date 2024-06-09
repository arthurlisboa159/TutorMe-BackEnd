using MediatR;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Commands.PostCommands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IPostRepository _postRepository;
    private readonly ISubjectGroupRepository _subjectGroupRepository;
    private readonly IUserRepository _userRepository;
    
    public CreatePostCommandHandler(IPostRepository postRepository, ISubjectGroupRepository subjectGroupRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _subjectGroupRepository = subjectGroupRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var subjectGroupId = await _subjectGroupRepository.GetIdByNameAsync(request.SubjectGroupName);
        var userId = await _userRepository.GetIdByEmailAsync(request.UserEmail);
        
        var post = new Core.Entities.Post(request.Title, request.FinalContent, subjectGroupId, userId);

        await _postRepository.AddAsync(post);
        
        return post.Id;
    }
}