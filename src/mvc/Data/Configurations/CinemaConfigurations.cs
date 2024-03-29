﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Data.Configurations
{
    public class CinemaConfigurations : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(c => c.Id);

            // properties
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Description).IsRequired();

        }
    }
}
