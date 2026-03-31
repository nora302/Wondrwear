namespace Wondwear.Infrastructure.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);

        // ✅ Correction PostgreSQL
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.UserName)
               .HasMaxLength(100)
               .IsRequired(true)
               .IsUnicode();

        builder.Property(b => b.Email)
               .HasMaxLength(100)
               .IsRequired(false);

        builder.Property(b => b.PhoneNumber)
               .HasMaxLength(25)
               .IsRequired(false);

        builder.Property(b => b.FcmToken)
               .IsRequired(false);

        builder.HasIndex(u => new
        {
            u.UserName,
            u.NormalizedUserName
        }).IsUnique(true);

        builder.UseTptMappingStrategy();
        builder.ToTable(nameof(User));
    }
}