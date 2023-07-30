using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            // properties
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.MovieCategory).IsRequired();
            builder.Property(m => m.EndDate).IsRequired();
            builder.Property(m => m.StratDate).IsRequired();

            // relationships
            builder.HasOne(m => m.Director)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.DirectorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Cinema)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
