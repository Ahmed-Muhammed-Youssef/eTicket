using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Price).IsRequired();
            builder.Property(ci => ci.Amount).IsRequired();

            // Relationships

            builder.HasOne(ci => ci.Movie)
                .WithMany()
                .HasForeignKey(ci => ci.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
