using GofConsoleApp.Examples.Structural.BridgePattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.BridgePattern;

[TestFixture]
[TestOf(typeof(BridgePatternExampleWithMarker))]
internal class BridgePatternExampleWithMarkerTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 10;
        var sut = new BridgePatternExampleWithMarker();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}