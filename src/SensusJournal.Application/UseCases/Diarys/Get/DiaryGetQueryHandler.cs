using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SensusJournal.Application.Abstractions;
using SensusJournal.Application.Interfaces.Data;

namespace SensusJournal.Application.UseCases.Diarys.Get;

public class DiaryGetQueryHandler
    : IQueryHandler<DiaryGetQuery, IReadOnlyCollection<DiaryGetResponse>>
{
    private readonly ISensusJournalDbContext _dbContext;
    private readonly IMapper _mapper;

    public DiaryGetQueryHandler(ISensusJournalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyCollection<DiaryGetResponse>>> Handle(DiaryGetQuery request, 
                                                                            CancellationToken cancellationToken = default)
    {
        var userId = request.ApplicationUserId;

        try
        {
            var queryResult = await _dbContext.Diarys
                .Where(d => !userId.HasValue || (d.UserId.HasValue && d.UserId.Value == userId.Value))
                .ToListAsync();

            var result = _mapper.Map<List<DiaryGetResponse>>(queryResult);

            return Result<IReadOnlyCollection<DiaryGetResponse>>.Success(result.AsReadOnly());

        }
        catch (Exception ex) 
        {
            return Result<IReadOnlyCollection<DiaryGetResponse>>.Failure(ex.Message);
        }

    }
}