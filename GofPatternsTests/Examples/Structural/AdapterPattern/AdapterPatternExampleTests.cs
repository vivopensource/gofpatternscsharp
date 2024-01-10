using GofConsoleApp.Examples.Structural.AdapterPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.AdapterPattern;

[TestFixture]
internal class AdapterPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 4;
        var sut = new AdapterPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}