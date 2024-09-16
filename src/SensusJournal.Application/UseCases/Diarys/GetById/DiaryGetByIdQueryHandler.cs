using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SensusJournal.Application.Abstractions;
using SensusJournal.Application.Interfaces.Data;

namespace SensusJournal.Application.UseCases.Diarys.GetById;

public class DiaryGetByIdQueryHandler
    : IQueryHandler<DiaryGetByIdQuery, DiaryGetByIdResponse>
{
    private readonly ISensusJournalDbContext _dbContext;
    private readonly IMapper _mapper;

    public DiaryGetByIdQueryHandler(ISensusJournalDbContext dbContext, 
                                    IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Result<DiaryGetByIdResponse>> Handle(DiaryGetByIdQuery request, 
                                                           CancellationToken cancellationToken)
    {
        var id = request.Id;
        var userId = request.ApplicationUserId;

        try
        {
            var queryResult = await _dbContext.Diarys
                .SingleOrDefaultAsync(d => (d.Id == id) &&
                                           (!userId.HasValue ||
                                               (d.UserId.HasValue && d.UserId.Value == userId.Value)));

            if (queryResult == null)
            {
                return Result<DiaryGetByIdResponse>
                    .Failure($"User with Id={id} not found", ErrorType.NotFound);
            }

            var result = _mapper.Map<DiaryGetByIdResponse>(queryResult);

            return Result<DiaryGetByIdResponse>.Success(result);

        }
        catch (Exception ex)
        {
            return Result<DiaryGetByIdResponse>.Failure(ex.Message);
        }
    }
}