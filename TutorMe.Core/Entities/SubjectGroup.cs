namespace TutorMe.Core.Entities;

public class SubjectGroup : BaseEntity
{
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Guid CreatorId { get; private set; }
    public User Creator { get; private set; }
    public List<Subscription>? Subscribers { get; private set; }
    public List<Post>? Posts { get; private set; }
    public bool IsOfficial { get; private set; }

    public SubjectGroup(string name, Guid creatorId, bool isOfficial = false)
    {
        Name = name;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        CreatorId = creatorId;
        Subscribers = new List<Subscription>();
        Posts = new List<Post>();
        IsOfficial = isOfficial;
    }
}


