using SwapiScraping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwapiScraping.Mappings
{
    internal class BaseMappings<T> : IEntityTypeConfiguration<T> where T : Model
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(nameof(T));
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedNever();
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.UpdatedAt);
            builder.Ignore(c => c.SwId);
        }
    }
}
