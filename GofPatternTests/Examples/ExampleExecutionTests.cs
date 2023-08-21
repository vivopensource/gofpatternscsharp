using Core.Console;
using Core.Console.Interfaces;
using GofConsoleApp.Examples;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.PatternOptions;

namespace GofPatternTests.Examples;

[TestFixture]
internal class ExampleExecutionTests
{
    [Test]
    public void Run_ExecutesTheExample()
    {
        // arrange
        var reader = GetReader();

        // act
        var actualResult = ExampleExecution.Run(reader);

        // assert
        Assert.That(actualResult, Is.True);
    }

    private static IConsoleReader GetReader()
    {
        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(ChainOfResponsibilityOption);

        return new ConsoleReader(mockReader.Object);
    }
}