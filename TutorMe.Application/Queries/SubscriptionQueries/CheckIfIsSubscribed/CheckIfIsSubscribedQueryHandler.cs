using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Queries.SubscriptionQueries.CheckIfIsSubscribed;

public class CheckIfIsSubscribedQueryHandler : IRequestHandler<CheckIfIsSubscribedQuery, SubscriptionViewModel>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly ISubjectGroupRepository _subjectGroupRepository;
    private readonly IUserRepository _userRepository;
    
    public CheckIfIsSubscribedQueryHandler(
        ISubscriptionRepository subscriptionRepository, 
        ISubjectGroupRepository subjectGroupRepository,
        IUserRepository userRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _subjectGroupRepository = subjectGroupRepository;
        _userRepository = userRepository;
    }


    public async Task<SubscriptionViewModel> Handle(CheckIfIsSubscribedQuery request, CancellationToken cancellationToken)
    {
        var userId = await _userRepository.GetIdByEmailAsync(request.UserEmail);
        var subjectGroupId = await _subjectGroupRepository.GetIdByNameAsync(request.SubjectGroupName);

        var isSubscribed = await _subscriptionRepository.IsSubscribed(userId, subjectGroupId);

        return new SubscriptionViewModel(isSubscribed);
    }
}