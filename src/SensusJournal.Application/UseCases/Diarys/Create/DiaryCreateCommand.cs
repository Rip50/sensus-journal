using SensusJournal.Application.Abstractions;

namespace SensusJournal.Application.UseCases.Diarys.Create;

public record DiaryCreateCommand(string Name, string Details)
    : ICommand<DiaryCreateResponse>
{
}
