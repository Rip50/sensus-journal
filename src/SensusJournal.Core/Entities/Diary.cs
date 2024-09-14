namespace SensusJournal.Core.Entities;

public class Diary
{
    public Guid Id { get; set; }
    public ApplicationUser User { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    ICollection<Record> Records { get; set; }
}