using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Commands.UserCommands.LoginUser;

public class LoginUserCommand : IRequest<LoginUserViewModel?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}