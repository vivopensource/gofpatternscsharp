using GofConsoleApp.Examples.Structural.ProxyPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.ProxyPattern;

[TestFixture]
internal class NewsChannelExampleBoundedAccessTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[] { EnumNewsChannel.Uzt.ToString() });

        var expectedReaderCount = readerValues.Count;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var sut = new NewsChannelExampleBoundedAccess();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
    }

    [Test]
    public void Execute_QuitsExampleIfExitOptionProvided_ReturnsFalse()
    {
        // arrange
        var readerValues = new Queue<string>(new[] { "Quit program" });

        var expectedReaderCount = readerValues.Count;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult =
            new NewsChannelExampleBoundedAccess().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
    }

    [Test]
    public void Execute_QuitsExampleIfUnBoundedInput_ThrowsException()
    {
        // arrange
        var readerValues = new Queue<string>(new[] { EnumNewsChannel.NotSet.ToString() });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 3;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new NewsChannelExampleBoundedAccess();

        // act
        Assert.Throws<ArgumentException>(() => example.Execute(MockConsoleLogger.Object, MockInputReader.Object));

        // assert
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }
}