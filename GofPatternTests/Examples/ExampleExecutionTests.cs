using Core.Console;
using GofConsoleApp.Examples;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.ExecutionHelpers.PatternOptions;

namespace GofPatternTests.Examples;

[TestFixture]
internal class ExampleExecutionTests
{
    [Test]
    public void Run_ExecutesTheExample()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            DecoratorPatternOption,
            "You are busted!!!"
        });

        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(readerValues.Dequeue);

        var reader = new InputReader(mockReader.Object);

        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));

        // act
        var actualResult = Execution.Run(logger, reader);

        // assert
        Assert.That(actualResult, Is.True);
    }
}