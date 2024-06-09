namespace TutorMe.Application.ViewModels;

public class PostDetailsViewModel
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public int IdUser { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsOpen { get; private set; }
    public string UserFullName { get; set; }

    public PostDetailsViewModel(string title, string content, int idUser, DateTime createdAt, bool isOpen, string userFullName)
    {
        Title = title;
        Content = content;
        IdUser = idUser;
        CreatedAt = createdAt;
        IsOpen = isOpen;
        UserFullName = userFullName;

    }
}