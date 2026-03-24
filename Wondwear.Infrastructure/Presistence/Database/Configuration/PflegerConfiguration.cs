

namespace Wondwear.Infrastructure.Database.Configuration;

public class PflegerConfiguration : IEntityTypeConfiguration<Pfleger>
{
    public void Configure(EntityTypeBuilder<Pfleger> builder)
    {
        

        builder.ToTable(nameof(Pfleger));
    }
}
