namespace SensusJournal.Core.Entities;

public class Emotion
{
    Guid Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public ICollection<Record> Records { get; set; }
}

