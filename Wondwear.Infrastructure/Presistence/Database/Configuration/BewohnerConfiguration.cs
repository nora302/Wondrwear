

namespace Wondwear.Infrastructure.Database.Configuration;

public class BewohnerConfiguration : IEntityTypeConfiguration<Bewohner>
{
    public void Configure(EntityTypeBuilder<Bewohner> builder)
    {


        builder.ToTable(nameof(Bewohner));
    }
}
