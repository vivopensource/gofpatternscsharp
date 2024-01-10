using GofConsoleApp.Examples.Behavioral.MediatorPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.MediatorPattern;

[TestFixture]
internal class MediatorPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 4;
        var sut = new MediatorPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
    
}