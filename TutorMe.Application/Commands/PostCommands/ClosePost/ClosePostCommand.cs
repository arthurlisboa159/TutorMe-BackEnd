using MediatR;

namespace TutorMe.Application.Commands.PostCommands.ClosePost;

public class ClosePostCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public ClosePostCommand(int id)
    {
        Id = id;
    }
}