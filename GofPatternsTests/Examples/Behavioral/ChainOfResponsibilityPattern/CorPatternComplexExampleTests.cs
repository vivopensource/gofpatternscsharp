using GofConsoleApp.Examples.Behavioral.CorPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.ChainOfResponsibilityPattern;

[TestFixture]
internal class CorPatternComplexExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        const int expectedNumberOfLogs = 9;

        var actualResult =
            new CorPatternComplexExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}