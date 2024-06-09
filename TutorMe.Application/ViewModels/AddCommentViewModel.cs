namespace TutorMe.Application.ViewModels;

public class AddCommentViewModel
{
    public Guid Id { get; set; }

    public AddCommentViewModel(Guid id)
    {
        Id = id;
    }
}