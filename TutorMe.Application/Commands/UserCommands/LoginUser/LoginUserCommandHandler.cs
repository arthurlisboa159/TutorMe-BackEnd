using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Repositories;
using TutorMe.Core.Services;

namespace TutorMe.Application.Commands.UserCommands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    
    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    
    
    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        if (user is null)
            return null;
        
        var token = _authService.GenerateJwtToken(user.Username, user.Email, user.Role);
        var loginUserViewModel = new LoginUserViewModel(user.Email, token);

        return loginUserViewModel;

    }
}