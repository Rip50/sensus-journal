using AutoMapper;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.UseCases.Diarys.GetById;

public class DiaryGetByIdMappingProfile : Profile
{
    public DiaryGetByIdMappingProfile()
    {
        CreateMap<Diary, DiaryGetByIdResponse>();
    }
}