using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensusJournal.Application.UseCases.Diarys.Create;

namespace SensusJournal.API.Endpoints;

public static class DiarysEndpoints
{
    public static void RegisterDiarysEndpoints(this WebApplication app)
    {
        var diarys = app.MapGroup("diarys");

        diarys.MapPost("/", Create).WithName(nameof(Create));
        diarys.MapGet("/", GetAll).WithName(nameof(GetAll));
        diarys.MapGet("/{id:guid}", GetById).WithName(nameof(GetById));
    }

    static async Task<IResult> Create([FromBody] DiaryCreateCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        if (result.IsSuccess)
        {
            return TypedResults.CreatedAtRoute(result.Response, nameof(GetById), new { Id = result.Response!.Id });
        }

        return TypedResults.Problem(result.Error);
    }

    static async Task<IResult> GetAll(ISender sender)
    {
        return TypedResults.Problem("Not implemented");
    }

    static async Task<IResult> GetById([FromRoute]Guid id, ISender sender)
    {
        return TypedResults.Problem("Not implemented");
    }
}