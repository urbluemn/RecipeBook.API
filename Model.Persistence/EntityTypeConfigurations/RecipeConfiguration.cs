using Recipes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Persistence.EntityTypeConfigurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(model => model.Id);
            builder.HasIndex(model => model.Id).IsUnique();
            builder.Property(model => model.Name).HasMaxLength(50);
            builder.Property(model => model.Description).HasMaxLength(50);
            builder.Property(model => model.Details).HasMaxLength(200);
        }
    }
}
