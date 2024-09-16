using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SensusJournal.Application.Interfaces.Data;
using SensusJournal.Application.UseCases.Diarys.Create;

namespace SensusJournal.Application.UnitTests;

public class DiaryCreateCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly ISensusJournalDbContext _sensusJournalDbContext;
    public DiaryCreateCommandHandlerTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DiaryCreateMappingProfile>();
        });

        _mapper = config.CreateMapper();
        _sensusJournalDbContext = Substitute.For<ISensusJournalDbContext>();
    }

    private DiaryCreateCommandHandler CreateSystemUnderTest()
    {
        return new DiaryCreateCommandHandler(_sensusJournalDbContext, _mapper);
    }

    [Fact]
    public async Task Handle_ValidCommandReceived_EntityCreated()
    {
        // Assume
        var command = new DiaryCreateCommand("Test name", "Test details");
        
        // Act
        var handler = CreateSystemUnderTest();
        var result = await handler.Handle(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Response.Should().NotBeNull();
        result.Response!.Name.Should().Be(command.Name);
        result.Response!.Details.Should().Be(command.Details);
    }

    [Fact]
    public async Task Handle_SqlExceptionRaised_ErrorReturned()
    {
        // Assume
        var command = new DiaryCreateCommand("Test name", "Test details");
        _sensusJournalDbContext.SaveChangesAsync(Arg.Any<CancellationToken>())
            .ThrowsForAnyArgs(_ => new DbUpdateConcurrencyException("Concurrency related error"));

        // Act
        var handler = CreateSystemUnderTest();
        var result = await handler.Handle(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Response.Should().BeNull();
        result.Error.Should().Be("Concurrency related error");
    }
}