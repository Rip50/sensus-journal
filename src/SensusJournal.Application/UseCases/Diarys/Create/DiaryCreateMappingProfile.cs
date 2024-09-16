using AutoMapper;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.UseCases.Diarys.Create;

public class DiaryCreateMappingProfile : Profile
{
    public DiaryCreateMappingProfile()
    {
        CreateMap<DiaryCreateCommand, Diary>();
        CreateMap<Diary, DiaryCreateResponse>();
    }
}