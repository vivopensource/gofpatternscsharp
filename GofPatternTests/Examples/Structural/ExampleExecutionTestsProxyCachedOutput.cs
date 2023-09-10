using Core.Console;
using Core.Extensions;
using GofConsoleApp.Examples;
using GofConsoleApp.Examples.Structural.ProxyPattern.CachedOutput;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.ExecutionHelpers.PatternOptions;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class ExampleExecutionTestsProxyCachedOutput
{
    [Test]
    public void Run_ExecutesExample_ProxyCachedOutput()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            ProxyPatternOption,
            EnumConfigEnv.Dev.ToString(),
            EnumConfigEnv.Prod.ToString(),
            EnumConfigEnv.Prod.ToString(),
            EnumConfigEnv.Dev.ToString(),
            EnumConfigEnv.Test.ToString(),
            "Quit program"
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