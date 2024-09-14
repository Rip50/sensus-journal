using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class RecordMappings : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.ToTable("Record");

        builder.HasMany(r => r.Emotions)
            .WithMany(e => e.Records)
            .UsingEntity("EmotionsRecords");
    }
}