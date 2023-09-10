using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityPatternExampleInputTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        var actualResult =
            new ChainOfResponsibilityPatternExampleInput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(34));
    }
}