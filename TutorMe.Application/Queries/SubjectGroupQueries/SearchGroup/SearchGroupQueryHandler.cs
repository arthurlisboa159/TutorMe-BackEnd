using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Queries.SubjectGroupQueries.SearchGroup;

public class SearchGroupQueryHandler : IRequestHandler<SearchGroupQuery, SearchGroupViewModel>
{
    private readonly ISubjectGroupRepository _subjectGroupRepository;

    public SearchGroupQueryHandler(ISubjectGroupRepository subjectGroupRepository)
    {
        _subjectGroupRepository = subjectGroupRepository;
    }

    public async Task<SearchGroupViewModel> Handle(SearchGroupQuery request, CancellationToken cancellationToken)
    {
        
        var subjectGroupsFound  = await _subjectGroupRepository.SearchGroup(request.Name);

        return new SearchGroupViewModel(subjectGroupsFound);

    }
}