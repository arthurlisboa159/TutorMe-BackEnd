using MediatR;
using TutorMe.Application.ViewModels;

namespace TutorMe.Application.Queries.SubjectGroupQueries.GetSubjectGroupByName;

public class GetSubjectGroupByNameQuery : IRequest<SubjectGroupViewModel>
{
    public string Name { get; set; }

    public GetSubjectGroupByNameQuery(string name)
    {
        Name = name;
    }
}