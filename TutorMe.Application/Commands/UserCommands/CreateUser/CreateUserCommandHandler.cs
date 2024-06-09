using MediatR;
using TutorMe.Core.Entities;
using TutorMe.Core.Repositories;
using TutorMe.Core.Services;

namespace TutorMe.Application.Commands.UserCommands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        var user = new User(
            request.FullName,
            request.Email,
            request.BirthDate,
            request.Registration,
            request.Course,
            request.Username,
            request.Role,
            passwordHash,
            request.IsTutor);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
    
}