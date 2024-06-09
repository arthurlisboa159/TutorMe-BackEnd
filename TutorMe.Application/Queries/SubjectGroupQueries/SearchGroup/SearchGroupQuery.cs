using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Queries.SubjectGroupQueries.SearchGroup;

public class SearchGroupQuery : IRequest<SearchGroupViewModel>
{
    public string Name { get; set; }
}