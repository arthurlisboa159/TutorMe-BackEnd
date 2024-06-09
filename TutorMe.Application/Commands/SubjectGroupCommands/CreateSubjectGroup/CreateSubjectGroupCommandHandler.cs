using MediatR;
using TutorMe.Core.Entities;
using TutorMe.Core.Enums;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Commands.SubjectGroupCommands.CreateSubjectGroup;

public class CreateSubjectGroupCommandHandler : 
    IRequestHandler<CreateSubjectGroupCommand, Guid?>
{
    private readonly ISubjectGroupRepository _subjectGroupRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;
    
    public CreateSubjectGroupCommandHandler(
        ISubjectGroupRepository subjectGroupRepository, 
        IUserRepository userRepository, 
        ISubscriptionRepository subscriptionRepository
    )
    {
        _subjectGroupRepository = subjectGroupRepository;
        _userRepository = userRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<Guid?> Handle(
        CreateSubjectGroupCommand request, 
        CancellationToken cancellationToken
    )
    {
        var userId = await _userRepository
            .GetIdByEmailAsync(request.UserEmail);
        var user = await _userRepository.SelectAsync(userId);
        
        var subjectGroup = new SubjectGroup(
            request.Name, userId, 
            user!.Role == RoleEnum.ADMIN
        );
        
        await _subjectGroupRepository.AddAsync(subjectGroup);
        
        var subscription = new Subscription(userId, subjectGroup.Id);
        await _subscriptionRepository.AddAsync(subscription);
        
        return subjectGroup.Id;
    }
}

