using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class ActorConfiguirations : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            // properties
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.FullName).IsRequired();
            builder.Property(a => a.ProfilePictureUrl).IsRequired();
            builder.Property(a => a.Bio).IsRequired();

           
        }
    }
}
