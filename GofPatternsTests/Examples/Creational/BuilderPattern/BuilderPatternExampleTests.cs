using GofConsoleApp.Examples.Creational.BuilderPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Creational.BuilderPattern;

[TestFixture]
internal class BuilderPatternExampleTests : BaseTest
{
    private const int LogCountForInput = 2;

    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            "1.1", "2.2", "exit"
        });

        var expectedReaderCount = readerValues.Count;
        var expectedLogCount = 1 + expectedReaderCount * LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var sut = new BuilderPatternExample();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }
}