


namespace Wondwear.Infrastructure.Database.Configuration;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable(nameof(Admin));
    }
}
