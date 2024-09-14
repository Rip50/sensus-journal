using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class CategoryMappings : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasMany(c => c.Emotions)
            .WithOne(e => e.Category)
            .HasForeignKey();
    }
}