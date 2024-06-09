using MediatR;
using TutorMe.Application.ViewModels;
using TutorMe.Core.Repositories;

namespace TutorMe.Application.Queries.SubjectGroupQueries.GetSubjectGroupByName;

public class GetSubjectGroupByNameQueryHandler : IRequestHandler<GetSubjectGroupByNameQuery, SubjectGroupViewModel>
{

    private readonly ISubjectGroupRepository _subjectGroupRepository;

    public GetSubjectGroupByNameQueryHandler(ISubjectGroupRepository subjectGroupRepository)
    {
        _subjectGroupRepository = subjectGroupRepository;
    }

    public async Task<SubjectGroupViewModel> Handle(GetSubjectGroupByNameQuery request, CancellationToken cancellationToken)
    {

        var subjectGroup = await _subjectGroupRepository.GetByNameAsync(request.Name);

        return new SubjectGroupViewModel(
            subjectGroup.Id,
            subjectGroup.Name,
            subjectGroup.CreatedAt.ToString("MM/dd/yyyy"),
            subjectGroup.UpdatedAt,
            subjectGroup.Creator,
            subjectGroup.Subscribers,
            subjectGroup.Posts,
            subjectGroup.IsOfficial
        );
    }
}