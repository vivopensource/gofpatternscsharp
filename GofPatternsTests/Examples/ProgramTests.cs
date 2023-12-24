using GofConsoleApp;
using GofConsoleApp.Examples.ExecutionHelpers;
using NUnit.Framework;

namespace GofPatternsTests.Examples;

[TestFixture]
internal class ProgramTests
{
    [Test]
    public void Main_ExecutesProgram_ReturnsTrue()
    {
        // arrange
        var args = new[]
        {
            "InvalidOptions",
            PatternOptions.ChainOfResponsibilityPatternOption2
        };

        // act
        Assert.DoesNotThrow(() => Program.Main(args));
    }

    [Test]
    public void BuildReaderFromArgument_IfHasArgumentUsesArgumentForReaderBuilding_ReturnsReader()
    {
        // arrange
        const string value1 = "Value1";
        const string value2 = "Value2";
        var args = new[] { value1, value2 };

        // act
        var actualResult = Program.BuildReaderFromArgument(args, Console.In);

        // assert
        Assert.That(actualResult.ReadLine(), Is.EqualTo(value1));
        Assert.That(actualResult.ReadLine(), Is.EqualTo(value2));
    }

    [Test]
    public void BuildReaderFromArgument_IfEmptyArgumentUsesDefaultValue_ReturnsReader()
    {
        // arrange
        var expectedResult = Console.In;

        // act
        var actualResult = Program.BuildReaderFromArgument(Array.Empty<string>(), expectedResult);

        // assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}