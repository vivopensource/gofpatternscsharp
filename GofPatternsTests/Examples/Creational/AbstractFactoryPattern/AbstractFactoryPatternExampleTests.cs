using GofConsoleApp.Examples.Creational.AbstractFactoryPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Creational.AbstractFactoryPattern;

[TestFixture]
internal class AbstractFactoryPatternExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedNumberOfLogs = 2;
        var sut = new AbstractFactoryPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedNumberOfLogs));
    }
}