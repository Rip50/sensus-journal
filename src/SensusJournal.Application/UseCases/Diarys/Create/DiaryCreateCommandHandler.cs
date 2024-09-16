using AutoMapper;
using SensusJournal.Application.Abstractions;
using SensusJournal.Application.Interfaces.Data;
using SensusJournal.Core.Entities;

namespace SensusJournal.Application.UseCases.Diarys.Create;

public class DiaryCreateCommandHandler 
    : ICommandHandler<DiaryCreateCommand, DiaryCreateResponse>
{
    private readonly ISensusJournalDbContext _dbContext;
    private readonly IMapper _mapper;

    public DiaryCreateCommandHandler(ISensusJournalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<DiaryCreateResponse>> Handle(DiaryCreateCommand request, CancellationToken cancellationToken = default)
    {
        // Create entity
        var diary = _mapper.Map<Diary>(request);

        try
        {
            await _dbContext.Diarys.AddAsync(diary);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return Result<DiaryCreateResponse>.Failure(ex.Message);
        }

        return Result<DiaryCreateResponse>.Success(_mapper.Map<DiaryCreateResponse>(diary));
    }
}