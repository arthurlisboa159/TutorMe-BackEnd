using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
{
    public void Configure(EntityTypeBuilder<CommentLike> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasOne(c => c.User)
            .WithMany(u => u.CommentLikes)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        
        builder
            .HasOne(c => c.PostComment)
            .WithMany(u => u.Likes)
            .HasForeignKey(p => p.PostCommentId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}