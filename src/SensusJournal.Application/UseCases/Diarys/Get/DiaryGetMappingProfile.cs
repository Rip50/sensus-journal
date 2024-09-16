using AutoMapper;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.UseCases.Diarys.Get;

public class DiaryGetMappingProfile : Profile
{
    public DiaryGetMappingProfile()
    {
        CreateMap<Diary, DiaryGetResponse>();
    }
}