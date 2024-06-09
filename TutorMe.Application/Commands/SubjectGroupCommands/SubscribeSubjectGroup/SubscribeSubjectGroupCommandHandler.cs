using MediatR;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Commands.SubjectGroupCommands.SubscribeSubjectGroup;

public class SubscribeSubjectGroupCommandHandler : IRequestHandler<SubscribeSubjectGroupCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly ISubjectGroupRepository _subjectGroupRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscribeSubjectGroupCommandHandler(IUserRepository userRepository, ISubjectGroupRepository subjectGroupRepository, ISubscriptionRepository subscriptionRepository)
    {
        _userRepository = userRepository;
        _subjectGroupRepository = subjectGroupRepository;
        _subscriptionRepository = subscriptionRepository;
    }


    public async Task<Unit> Handle(SubscribeSubjectGroupCommand request, CancellationToken cancellationToken)
    {
        var subjectGroupId = await _subjectGroupRepository.GetIdByNameAsync(request.Name);
        var userId = await _userRepository.GetIdByEmailAsync(request.Email);
        
        await _subscriptionRepository.Subscribe(userId, subjectGroupId);
        
        return Unit.Value;
    }
}