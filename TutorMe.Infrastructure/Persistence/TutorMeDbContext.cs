using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence;

public class TutorMeDbContext : DbContext
{
    public DbSet<CommentLike> CommentLikes { get;  set; }
    
    public DbSet<Post> Posts { get;  set; }
    public DbSet<PostComment> PostComments { get; set; }
    
    public DbSet<PostLike> PostLikes { get;  set; }
    
    public DbSet<SubjectGroup> SubjectGroups { get;  set; }

    public DbSet<Subscription> Subscriptions { get;  set; }
    
    public DbSet<User?> Users { get;  set; }
    
    public TutorMeDbContext(DbContextOptions<TutorMeDbContext> options) : base (options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}