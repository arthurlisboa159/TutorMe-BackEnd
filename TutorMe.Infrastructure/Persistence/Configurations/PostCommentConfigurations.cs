using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class PostCommentConfigurations : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(p => p.Likes);
    }

}