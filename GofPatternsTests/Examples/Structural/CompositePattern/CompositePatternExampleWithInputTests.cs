using GofConsoleApp.Examples.Structural.CompositePattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.CompositePattern;

[TestFixture]
[TestOf(typeof(CompositePatternExampleWithInput))]
internal class CompositePatternExampleWithInputTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 10;
        var sut = new CompositePatternExampleWithInput();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}