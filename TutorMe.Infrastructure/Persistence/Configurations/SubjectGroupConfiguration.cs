using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class SubjectGroupConfiguration : IEntityTypeConfiguration<SubjectGroup>
{
    public void Configure(EntityTypeBuilder<SubjectGroup> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .HasOne(s => s.Creator)
            .WithMany(u => u.CreatedSubjectGroups)
            .HasForeignKey(s => s.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);;

        builder
            .HasMany(s => s.Subscribers);

        builder
            .HasMany(s => s.Posts);
    }
}

