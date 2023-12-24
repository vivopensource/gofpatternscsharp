using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.ChainOfResponsibilityPattern;

[TestFixture]
internal class CorPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        const int expectedNumberOfLogs = 27;

        var actualResult =
            new CorPatternExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}