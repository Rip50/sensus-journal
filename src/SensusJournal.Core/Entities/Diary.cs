namespace SensusJournal.Core.Entities;

public class Diary
{
    public Guid Id { get; set; }
    public ApplicationUser User { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public ICollection<Record> Records { get; set; }
}