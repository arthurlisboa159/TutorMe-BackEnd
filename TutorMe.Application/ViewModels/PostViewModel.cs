namespace TutorMe.Application.ViewModels;

public class PostViewModel
{
    public int IdPost { get; private set; }
    
    public int IdUser { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public PostViewModel(int idPost, int idUser, string title, DateTime createdAt)
    {
        IdPost = idPost;
        IdUser = idUser;
        Title = title;
        CreatedAt = createdAt;
    }
}