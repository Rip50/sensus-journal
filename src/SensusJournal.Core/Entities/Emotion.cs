namespace SensusJournal.Core.Entities;

public class Emotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Record> Records { get; set; }
}

