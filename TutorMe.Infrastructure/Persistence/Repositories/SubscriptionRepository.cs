using Microsoft.EntityFrameworkCore;
using TutorMe.Core.Entities;
using TutorMe.Core.Exceptions;
using TutorMe.Core.Repositories;

namespace TutorMe.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly TutorMeDbContext _dbContext;

    public SubscriptionRepository(TutorMeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(Subscription subscription)
    {
        bool alreadyExists = _dbContext.Subscriptions.Any(
            s => s.UserId == subscription.UserId 
            && s.SubjectGroupId == subscription.SubjectGroupId);

        if (alreadyExists)
            throw new EntityAlreadyExistsException();
        
        await _dbContext.AddAsync(subscription);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsSubscribed(Guid userId, Guid subjectGroupId)
    {
        var subscription = await _dbContext.Subscriptions.SingleOrDefaultAsync(
            s => s.UserId == userId
                 && s.SubjectGroupId == subjectGroupId);

        if (subscription is null)
            return false;
        
        return subscription.IsActive;
    }

    private async Task<bool> SubscriptionExists(Guid userId, Guid subjectGroupId)
    {
        return await _dbContext.Subscriptions.AnyAsync(
            s => s.UserId == userId && s.SubjectGroupId == subjectGroupId);
    }

    public async Task Subscribe(Guid userId, Guid subjectGroupId)
    {
        if (await SubscriptionExists(userId, subjectGroupId))
        {
            var subscription = await _dbContext.Subscriptions.SingleOrDefaultAsync(
                s => s.UserId == userId
                     && s.SubjectGroupId == subjectGroupId);
            
            subscription!.IsActive = !subscription.IsActive;

            _dbContext.Update(subscription);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            await AddAsync(new Subscription(userId, subjectGroupId));
        }
    }
    
}