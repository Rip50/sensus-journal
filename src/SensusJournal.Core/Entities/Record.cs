namespace SensusJournal.Core.Entities;

public class Record
{
    public Guid Id { get; set; }
    public Guid DiaryId { get; set; }
    public Diary Diary { get; set; }
    public string Summary { get; set; }
    public string Details { get; set; }
    public DateTime EventTime { get; set; }
    public ICollection<Emotion> Emotions { get; set; }
}