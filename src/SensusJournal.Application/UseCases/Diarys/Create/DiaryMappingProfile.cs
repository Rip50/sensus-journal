using AutoMapper;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.UseCases.Diarys.Create;

public class DiaryMappingProfile : Profile
{
    public DiaryMappingProfile()
    {
        CreateMap<DiaryCreateCommand, Diary>();
        CreateMap<Diary, DiaryCreateResponse>();
    }
}