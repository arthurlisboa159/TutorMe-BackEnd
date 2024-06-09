using MediatR;

namespace TutorMe.Application.Commands.SubjectGroupCommands.SubscribeSubjectGroup;

public class SubscribeSubjectGroupCommand : IRequest<Unit>
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public SubscribeSubjectGroupCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
}