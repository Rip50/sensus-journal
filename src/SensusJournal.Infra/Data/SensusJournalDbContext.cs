using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensusJournal.Application.Interfaces.Data;
using SensusJournal.Core.Entities;

namespace SensusJournal.Infra.Data;

// Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618

public sealed class SensusJournalDbContext : IdentityDbContext<ApplicationUser>, ISensusJournalDbContext
{
    public DbSet<Diary> Diarys { get; set; }

    public DbSet<Record> Records { get; set; }

    public DbSet<SharedRecords> SharedRecords { get; set; }

    public DbSet<Reminder> Reminders { get; set; }

    public SensusJournalDbContext() { }

    public SensusJournalDbContext(DbContextOptions<SensusJournalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SensusJournalDbContext).Assembly);
    }
}