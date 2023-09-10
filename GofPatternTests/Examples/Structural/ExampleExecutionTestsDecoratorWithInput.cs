using Core.Console;
using Core.Extensions;
using GofConsoleApp.Examples;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.ExecutionHelpers.PatternOptions;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class ExampleExecutionTestsDecoratorWithInput
{
    [Test]
    public void Run_ExecutesExample_ProxyCachedOutput()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            DecoratorPatternOption,
            // Message to be sent via SMS (notifier) and Email (decorator on notifier)
            "Testing decorator pattern applied on the notification feature!!!"
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