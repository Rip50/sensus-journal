using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class SharedRecordsMappings : IEntityTypeConfiguration<SharedRecords>
{
    public void Configure(EntityTypeBuilder<SharedRecords> builder)
    {
        builder.ToTable("SharedRecords");

        builder.HasMany(sr => sr.Records)
            .WithMany()
            .UsingEntity("RecordsSharedRecords");
    }
}