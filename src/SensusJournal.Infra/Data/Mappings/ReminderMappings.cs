using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data.Mappings;

internal class ReminderMappings : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.ToTable("Reminder");

        builder.HasOne(r => r.User)
            .WithMany();

        builder.OwnsOne(r => r.Schedule, s =>
        {
            s.Property(p => p.CronExpression).HasColumnName("ReminderCronExpression");
        });
    }
}