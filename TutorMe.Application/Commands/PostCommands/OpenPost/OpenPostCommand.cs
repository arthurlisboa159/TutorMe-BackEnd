using MediatR;

namespace TutorMe.Application.Commands.PostCommands.OpenPost;

public class OpenPostCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public OpenPostCommand(int id)
    {
        Id = id;
    }
}