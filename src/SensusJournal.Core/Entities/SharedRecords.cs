namespace SensusJournal.Core.Entities;

public class SharedRecords
{
    public Guid Id { get; set; }
    public ICollection<Record> Records { get; set; }
}
