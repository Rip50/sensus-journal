using SensusJournal.Application.Abstractions;

namespace SensusJournal.Application.UseCases.Diarys.Get;

public record DiaryGetQuery(Guid? ApplicationUserId) 
    : IQuery<IReadOnlyCollection<DiaryGetResponse>>
{
    public static DiaryGetQuery All => new DiaryGetQuery((Guid?)null);
}
