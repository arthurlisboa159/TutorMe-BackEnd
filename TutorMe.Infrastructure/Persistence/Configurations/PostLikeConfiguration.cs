using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasOne(c => c.User)
            .WithMany(u => u.PostLikes)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);;

        builder
            .HasOne(c => c.Post)
            .WithMany(u => u.PostLikes)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}