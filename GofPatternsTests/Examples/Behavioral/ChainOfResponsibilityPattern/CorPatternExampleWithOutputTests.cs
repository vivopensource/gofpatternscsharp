using GofConsoleApp.Examples.Behavioral.CorPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.ChainOfResponsibilityPattern;

[TestFixture]
internal class CorPatternExampleWithOutputTests : BaseTest
{
    [Test]
    public void ChainOfResponsibilityExampleWithInputOutput_Execute()
    {
        // act
        const int expectedNumberOfLogs = 4;

        var actualResult =
            new CorPatternExampleWithOutput().Execute(MockConsoleLogger.Object,
                MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}