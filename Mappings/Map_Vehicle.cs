using SwapiScraping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwapiScraping.Mappings
{
    internal class Map_Vehicle : BaseMappings<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);
            builder.ToTable("Vehicles");

            builder.Property(c => c.Name);
            builder.Property(c => c.Model);
            builder.Property(c => c.Manufacturer);
            builder.Property(c => c.CostInCredits);
            builder.Property(c => c.Length);
            builder.Property(c => c.MaxSpeed);
            builder.Property(c => c.Crew);
            builder.Property(c => c.Passengers);
            builder.Property(c => c.CargoCapacity);
            builder.Property(c => c.Consumables);
            builder.Property(c => c.Class);

            builder.HasMany(c => c.Movies)
                .WithMany(c => c.Vehicles);

            builder.Ignore(c => c.MoviesSwIds);

        }
    }
}
