using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class PostConfigurations: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.SubjectGroup)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.SubjectGroupId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post);

        builder
            .HasMany(p => p.PostLikes)
            .WithOne(p => p.Post);

    }
}