using Microsoft.EntityFrameworkCore;
using TutorMe.Core.Entities;
using TutorMe.Core.Exceptions;
using TutorMe.Core.Repositories;
using TutorMe.Core.Utils;

namespace TutorMe.Infrastructure.Persistence.Repositories;

public class SubjectGroupRepository : ISubjectGroupRepository
{
    private readonly TutorMeDbContext _dbContext;

    public SubjectGroupRepository(TutorMeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(SubjectGroup subjectGroup)
    {

        bool alreadyExists = _dbContext.SubjectGroups.Any(p => p.Name == subjectGroup.Name);

        if (alreadyExists)
            throw new EntityAlreadyExistsException();
        
        await _dbContext.AddAsync(subjectGroup);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task<SubjectGroup> GetByNameAsync(string name)
    {
        var subjectGroup = await _dbContext.SubjectGroups
            .Include(sg => sg.Posts)
            .Include(sg => sg.Subscribers!.Where(sub => sub.IsActive == true))
            .Include(sg => sg.Creator)
            .SingleOrDefaultAsync(sg => sg.Name.Equals(name));

        if (subjectGroup is null)
            throw new EntityNotFoundException();

        return subjectGroup;
    }

    public async Task<Guid> GetIdByNameAsync(string name)
    {
        var subjectGroup = await _dbContext.SubjectGroups.SingleOrDefaultAsync(s => s.Name == name);
        
        return subjectGroup?.Id ?? default(Guid);
    }

    public async Task<ICollection<GroupInfo>> SearchGroup(string name)
    {
        return await _dbContext.SubjectGroups
            .Where(s => s.Name.Contains(name))
            .OrderByDescending(s => s.IsOfficial)
            .Select(s => new GroupInfo
            {
                Name = s.Name,
                IsOfficial = s.IsOfficial
            })
            .Take(10)
            .ToListAsync();
    }
}