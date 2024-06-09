namespace TutorMe.Core.Entities;

public class PostComment : BaseEntity
{
    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    
    public Guid PostId { get; private set; }
    public Post Post { get; private set; }
    
    public List<CommentLike>? Likes { get; private set; }

    public PostComment(string text, Guid userId, Guid postId)
    {
        Text = text;
        UserId = userId;
        PostId = postId;
        CreatedAt = DateTime.Now;
    }
}