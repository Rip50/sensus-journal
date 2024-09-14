using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class DiaryMappings : IEntityTypeConfiguration<Diary>
{
    public void Configure(EntityTypeBuilder<Diary> builder)
    {
        builder.ToTable("Diary");

        builder.HasMany(d => d.Records)
            .WithOne(d => d.Diary)
            .HasForeignKey();

        builder.HasOne(d => d.User)
            .WithMany(u => u.Diarys);
    }
}