using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class ProducerConfigurations : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(p => p.Id);

            // properties
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Bio).IsRequired();
        }
    }
}
