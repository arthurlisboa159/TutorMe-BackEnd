using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .HasMany(u => u.Posts);
        
        builder
            .HasMany(u => u.PostComments);
        
        builder
            .HasMany(u => u.PostLikes);
        
        builder
            .HasMany(u => u.Subscriptions);
        
        builder
            .HasMany(u => u.CreatedSubjectGroups);
        
        builder
            .HasMany(u => u.CommentLikes);

        builder
            .Property(e => e.Role)
            .HasConversion<string>();

    }
}