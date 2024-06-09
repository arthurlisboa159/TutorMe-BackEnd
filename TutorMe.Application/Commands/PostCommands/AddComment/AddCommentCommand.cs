using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Commands.PostCommands.AddComment;

public class AddCommentCommand : IRequest<AddCommentViewModel>
{
    public Guid PostId { get; set; }
    public string Text { get; set; }
    public Guid ReplyToId { get; set; }
    public string UserEmail { get; private set; }

    public void setUserEmail(string email)
    {
        UserEmail = email;
    }
}