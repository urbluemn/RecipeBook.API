using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain;

namespace Recipes.Persistence.EntityTypeConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);
            builder.HasIndex(image => image.Id).IsUnique();
            builder.Property(image => image.ImageTitle).HasMaxLength(50).IsRequired();
            builder.Property(image => image.ImagePath).IsRequired();
        }
    }
}