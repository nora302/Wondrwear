

using Notification = Wondwear.Domain.Entities.Notification;

namespace Wondwear.Infrastructure.Database.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn().ValueGeneratedOnAdd();
        builder.Property(n => n.Title).HasMaxLength(1000).IsRequired(true);
        builder.Property(n => n.Body).HasMaxLength(1000).IsRequired(true);

        builder.HasOne(n => n.User)
               .WithMany(u => u.Notifications)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(false);

        builder.HasIndex(u => new
        {
            u.UserId
        });
        builder.ToTable(nameof(Notification));
    }
}
