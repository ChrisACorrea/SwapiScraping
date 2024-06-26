﻿using SwapiScraping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SwapiScraping.Mappings
{
    internal class Map_Movie : BaseMappings<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);
            builder.ToTable("Movies");

            builder.Property(c => c.Title);
            builder.Property(c => c.Episode);
            builder.Property(c => c.OpeningCrawl);
            builder.Property(c => c.Director);
            builder.Property(c => c.Producer);
            builder.Property(c => c.ReleaseDate);

            builder.HasMany(c => c.Characters)
                .WithMany(c => c.Movies);

            builder.HasMany(c => c.Planets)
                .WithMany(c => c.Movies);

            builder.HasMany(c => c.Vehicles)
                .WithMany(c => c.Movies);

            builder.HasMany(c => c.Starships)
                .WithMany(c => c.Movies);

            builder.Ignore(c => c.CharactersSwIds);
            builder.Ignore(c => c.PlanetsSwIds);
            builder.Ignore(c => c.VehiclesSwIds);
            builder.Ignore(c => c.StarshipsSwIds);

        }
    }
}
