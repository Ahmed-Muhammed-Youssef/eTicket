using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Price).IsRequired();
            builder.Property(oi => oi.Amount).IsRequired();

            // Relationships

            builder.HasOne(oi => oi.Movie)
                .WithMany()
                .HasForeignKey(oi => oi.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
