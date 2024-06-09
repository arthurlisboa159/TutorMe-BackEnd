using TutorMe.Core.Entities;

namespace TutorMe.Core.Repositories;

public interface ISubscriptionRepository
{
    Task AddAsync(Subscription subscription);
    Task Subscribe(Guid userId, Guid subjectGroupId);
    Task<bool> IsSubscribed(Guid userId, Guid subjectGroupId);
}