using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class DirectorConfigurations : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(p => p.Id);

            // properties
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Bio).IsRequired();
        }
    }
}
