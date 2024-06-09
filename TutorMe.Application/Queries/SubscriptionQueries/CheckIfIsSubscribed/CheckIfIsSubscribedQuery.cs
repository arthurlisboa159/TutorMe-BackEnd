using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Queries.SubscriptionQueries.CheckIfIsSubscribed;

public class CheckIfIsSubscribedQuery : IRequest<SubscriptionViewModel>  
{
    public string SubjectGroupName { get; set; }

    public string UserEmail { get; private set; }

    public CheckIfIsSubscribedQuery(string subjectGroupName)
    {
        SubjectGroupName = subjectGroupName;
    }

    public void setUserEmail(string email)
    {
        UserEmail = email;
    }
}