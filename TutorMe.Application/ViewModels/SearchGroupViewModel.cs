using TutorMe.Core.Utils;

namespace TutorMe.Application.ViewModels;

public class SearchGroupViewModel
{
    public ICollection<GroupInfo> SubjectGroupsFound { get; set; }
    
    public SearchGroupViewModel(ICollection<GroupInfo> subjectGroupsFound)
    {
        SubjectGroupsFound = subjectGroupsFound;
    }
}