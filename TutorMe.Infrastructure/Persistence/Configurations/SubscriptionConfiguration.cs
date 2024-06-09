using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorMe.Core.Entities;

namespace TutorMe.Infrastructure.Persistence.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasOne(c => c.User)
            .WithMany(u => u.Subscriptions)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.SubjectGroup)
            .WithMany(u => u.Subscribers)
            .HasForeignKey(p => p.SubjectGroupId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}