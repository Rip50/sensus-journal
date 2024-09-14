using SensusJournal.Core.ValueObjects;

namespace SensusJournal.Core.Entities;

public class Reminder
{
    public Guid Id { get; set; }
    public ApplicationUser User { get; set; }
    public string Name { get; set; }
    public Schedule Schedule { get; set; }
}