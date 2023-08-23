using Core.Console;
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
        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(ChainOfResponsibilityPatternOption);
        var reader = new ConsoleReader(mockReader.Object);

        // act
        ExampleExecution.Run(reader);

        // assert
        mockReader.Verify(x => x.ReadLine(), Times.Exactly(1));
    }
}