using GofConsoleApp.Examples.Behavioral.CommandPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.CommandPattern;

[TestFixture]
internal class CommandPatternRestaurantExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        const int expectedVerifyCount = 9;

        var actualResult = new CommandPatternRestaurantExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedVerifyCount));
    }
}