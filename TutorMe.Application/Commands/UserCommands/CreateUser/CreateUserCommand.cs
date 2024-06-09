using MediatR;
using TutorMe.Core.Enums;

namespace TutorMe.Application.Commands.UserCommands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Registration { get; set; }
    public string Course { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public RoleEnum Role  { get; set; }
    public bool IsTutor { get; set; }
}