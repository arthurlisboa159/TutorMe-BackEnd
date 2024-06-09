using TutorMe.Core.Entities;
using TutorMe.Core.Utils;

namespace TutorMe.Core.Repositories;

public interface ISubjectGroupRepository
{
    Task AddAsync(SubjectGroup subjectGroup);
    Task<SubjectGroup> GetByNameAsync(string name);
    Task<Guid> GetIdByNameAsync(string name);
    Task<ICollection<GroupInfo>> SearchGroup(string name);
}


