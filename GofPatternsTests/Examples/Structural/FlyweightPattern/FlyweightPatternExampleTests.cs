using GofConsoleApp.Examples.Structural.FlyweightPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.FlyweightPattern;

[TestFixture]
internal class FlyweightPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 10;
        var sut = new FlyweightPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}