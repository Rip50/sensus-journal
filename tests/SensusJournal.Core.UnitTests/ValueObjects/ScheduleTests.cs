using FluentAssertions;
using SensusJournal.Core.ValueObjects;

namespace SensusJournal.Core.UnitTests.ValueObjects;

public class ScheduleTests
{
    [Theory]
    [InlineData("")]
    [InlineData("60 * * * *")]  // Invalid minute (60 is out of range)
    [InlineData("* 24 * * *")]  // Invalid hour (24 is out of range)
    [InlineData("* * 32 * *")]  // Invalid day of month (32 is out of range)
    [InlineData("* * * 13 *")]  // Invalid month (13 is out of range)
    [InlineData("* * * * 8")]   // Invalid day of week (8 is out of range)
    [InlineData("*/-5 * * * *")]  // Invalid step in minute field (negative step)
    [InlineData("* * 0-31 * *")]  // Invalid range (0 is out of range for day of month)
    [InlineData("* * * * * *")]  // Extra field (too many fields)
    [InlineData("* * * *")]      // Missing field (too few fields)
    [InlineData("invalid")]      // Totally invalid format (non-numeric)
    public void Create_InvalidCronExpression_Exception(string cronExpression)
    {
        // Act
        var act = () => Schedule.Create(cronExpression);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("* * * * *")]           // Every minute
    [InlineData("0 0 * * *")]           // At midnight every day
    [InlineData("0 12 * * 0")]          // Every Sunday at noon
    [InlineData("15 10 * * 1-5")]       // At 10:15 AM on weekdays (Mon-Fri)
    [InlineData("0 22 * * 1-5")]        // At 10:00 PM on weekdays
    [InlineData("5 4 * * *")]           // At 4:05 AM every day
    [InlineData("30 7 1 * *")]          // At 7:30 AM on the first day of every month
    [InlineData("0 0 1 1 *")]           // At midnight on the first of January
    [InlineData("0 23 5 7 *")]          // At 11:00 PM on July 5th
    [InlineData("0 22 * 3 *")]          // At 10:00 PM every day in March
    [InlineData("15 14 1 * *")]         // At 2:15 PM on the first day of every month
    [InlineData("0 0 * 5 *")]           // At midnight every day in May
    [InlineData("0 * 1-10 * 2-4")]      // At 1st and 10th day of the month on Tue-Thu
    [InlineData("0 0 1,15 * 3")]        // At midnight on the 1st and 15th of every month on Wednesday

    public void Create_ValidCronExpression_ObjectCreated(string cronExpression)
    {
        // Act
        var act = () => Schedule.Create(cronExpression);

        // Assert
        act.Should().NotThrow<Exception>();
    }
}