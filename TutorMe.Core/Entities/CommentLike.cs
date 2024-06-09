namespace TutorMe.Core.Entities;

public class CommentLike : BaseEntity
{
    public Guid UserId { get; private set; }
    public User User { get; set; }
    public Guid PostCommentId { get; private set; }
    public PostComment PostComment { get; private set; }
    
}