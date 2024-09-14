using Microsoft.EntityFrameworkCore;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.Interfaces.Data;

public interface ISensusJournalDbContext
{
    public DbSet<ApplicationUser> Users { get; }
    public DbSet<Diary> Diarys { get; }
    public DbSet<Record> Records { get; }
    public DbSet<SharedRecords> SharedRecords { get; }
    public DbSet<Reminder> Reminders { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}