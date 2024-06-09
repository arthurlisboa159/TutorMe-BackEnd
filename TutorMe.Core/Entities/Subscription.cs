namespace TutorMe.Core.Entities;

public class Subscription : BaseEntity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public Guid SubjectGroupId { get; private set; }
    public SubjectGroup SubjectGroup { get; private set; }

    public bool IsActive { get; set; }
    
    public Subscription(Guid userId, Guid subjectGroupId)
    {
        UserId = userId;
        SubjectGroupId = subjectGroupId;
        IsActive = true;
    }
}