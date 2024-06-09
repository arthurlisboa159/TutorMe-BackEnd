namespace TutorMe.Core.Entities;

public class Post : BaseEntity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public Guid SubjectGroupId { get; private set; }
    public SubjectGroup SubjectGroup { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; set; }
    
    public List<PostComment>? Comments { get; private set; }
    public List<PostLike>? PostLikes { get; private set; }


    public Post(string title, string content, Guid subjectGroupId, Guid userId)
    {
        Title = title;
        Content = content;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        SubjectGroupId = subjectGroupId;
        UserId = userId;
    }
}