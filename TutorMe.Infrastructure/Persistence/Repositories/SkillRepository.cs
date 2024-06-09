// using Microsoft.EntityFrameworkCore;
// using TutorMe.Core.Entities;
// using TutorMe.Core.Repositories;
//
// namespace TutorMe.Infrastructure.Persistence.Repositories;
//
// public class SkillRepository : ISkillRepository
// {
//     private readonly TutorMeDbContext _dbContext;
//     
//     public SkillRepository(TutorMeDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     
//     public async Task<List<Skill>> GetAllAsync()
//     {
//         return await _dbContext.Skills.ToListAsync();
//     }
//     
// }