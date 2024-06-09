using MediatR;

namespace TutorMe.Application.Commands.SubjectGroupCommands.CreateSubjectGroup;

public class CreateSubjectGroupCommand : IRequest<Guid?>
{
    public string Name { get; set; }
    public string UserEmail { get; private set; }

    public void SetEmail(string email)
    {
        UserEmail = email;
    }
}