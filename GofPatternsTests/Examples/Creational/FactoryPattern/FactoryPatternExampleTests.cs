using GofConsoleApp.Examples.Creational.FactoryPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Creational.FactoryPattern;

[TestFixture]
internal class FactoryPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 2;
        var sut = new FactoryPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}