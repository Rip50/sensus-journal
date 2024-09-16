using SensusJournal.Application.Abstractions;

namespace SensusJournal.Application.UseCases.Diarys.GetById;

public record DiaryGetByIdQuery(Guid Id, Guid? ApplicationUserId) 
    : IQuery<DiaryGetByIdResponse>
{
}
