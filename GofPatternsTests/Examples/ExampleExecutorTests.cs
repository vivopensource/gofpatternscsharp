using Core.Console;
using Core.Extensions;
using GofConsoleApp.Examples;
using GofConsoleApp.Examples.ExecutionHelpers;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples;

[TestFixture]
internal class ExampleExecutorTests
{
    [Test]
    public void Run_ExecutesExample_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            PatternOptions.ChainOfResponsibilityPatternOption2
        });

        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(readerValues.Dequeue);

        var reader = new InputReader(mockReader.Object);

        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));

        // act
        var actualResult = ExampleExecutor.Run(logger, reader);

        // assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void Run_RepeatsUntilValidInputExecutesExample_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            "InvalidOptions",
            PatternOptions.ChainOfResponsibilityPatternOption2
        });

        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(readerValues.Dequeue);

        var reader = new InputReader(mockReader.Object);

        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));

        // act
        var actualResult = ExampleExecutor.Run(logger, reader);

        // assert
        Assert.That(actualResult, Is.True);
    }
}