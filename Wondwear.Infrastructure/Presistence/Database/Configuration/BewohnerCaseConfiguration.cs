

using Notification = Wondwear.Domain.Entities.Notification;

namespace Wondwear.Infrastructure.Database.Configuration;

public class BewohnerCaseConfiguration : IEntityTypeConfiguration<BewohnerCase>
{
    public void Configure(EntityTypeBuilder<BewohnerCase> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();
        builder.HasOne(n => n.Bewohner)
               .WithMany(u => u.Cases)
               .HasForeignKey(u => u.BewohnerId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(true);

        builder.HasOne(n => n.Pfleger)
              .WithMany(u => u.Cases)
              .HasForeignKey(u => u.PflegerId)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired(false);

        builder.HasIndex(u => new
        {
            u.BewohnerId
        });
        builder.ToTable(nameof(BewohnerCase));
    }
}
