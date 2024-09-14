using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class EmotionMappings : IEntityTypeConfiguration<Emotion>
{
    public void Configure(EntityTypeBuilder<Emotion> builder)
    {
        builder.ToTable("Emotion");
    }
}