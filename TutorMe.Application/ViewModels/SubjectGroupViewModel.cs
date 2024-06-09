using TutorMe.Core.Entities;

namespace TutorMe.Application.ViewModels;

public class SubjectGroupViewModel
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Creator { get; private set; }
    public List<Subscription>? Subscribers { get; private set; }
    public List<Post>? Posts { get; private set; }
    public int NumberOfSubscribers { get; private set; }
    public int NumberOfPosts { get; private set; }
    public bool IsOfficial { get; private set; }

    public SubjectGroupViewModel(
        Guid id,
        string name,
        string createdAt, 
        DateTime updatedAt, 
        User creator, 
        List<Subscription>? subscribers, 
        List<Post>? posts,
        bool isOfficial
        )
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Creator = creator.FullName;
        Subscribers = subscribers;
        Posts = posts;
        NumberOfSubscribers = subscribers.Count;
        NumberOfPosts = posts.Count;
        IsOfficial = isOfficial;
    }
}