using MediatR;

namespace TutorMe.Application.Commands.PostCommands.CreatePost;

public class CreatePostCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string FinalContent { get; set; }
    public string SubjectGroupName { get; set; }
    public string UserEmail { get;  private set; }
    
    public void SetEmail(string email)
    {
        UserEmail = email;
    }
}