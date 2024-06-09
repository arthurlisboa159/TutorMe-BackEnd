namespace TutorMe.Application.ViewModels;

public class SubscriptionViewModel
{
    public bool isSubscribed { get; set; }

    public SubscriptionViewModel(bool isSubscribed)
    {
        this.isSubscribed = isSubscribed;
    }
}