using MediatR;

namespace TutorMe.Application.Commands.PostCommands.DeletePost;

public class DeletePostCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeletePostCommand(int id)
    {
        Id = id;
    }
}