namespace TutorMe.Application.ViewModels;

public class PostCommentViewModel
{
    public Guid Id { get; set; }
    public string Text { get; private set; }
    public Guid UserId { get; private set; }
    public Guid PostId { get; private set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsTutor { get; set; }

    public PostCommentViewModel(Guid id, string text, Guid userId, Guid postId, string username, DateTime createdAt, bool isTutor)
    {
        Id = id;
        Text = text;
        UserId = userId;
        PostId = postId;
        Username = username;
        CreatedAt = createdAt;
        IsTutor = isTutor;
    }
}