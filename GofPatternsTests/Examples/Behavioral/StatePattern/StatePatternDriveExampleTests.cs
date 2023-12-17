using GofConsoleApp.Examples;
using GofConsoleApp.Examples.Behavioral.StatePattern;
using GofConsoleApp.Examples.Behavioral.StatePattern.Drive;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.StatePattern.Drive.EnumStatePatternDriveExample;

namespace GofPatternsTests.Examples.Behavioral.StatePattern;

[TestFixture]
internal class StatePatternDriveExampleTests : BaseTest
{
    private const int LogCountForInput = 3;

    [Test]
    public void Execute_QuitsExampleIfInvalidOption_ReturnsFalse()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            Invalid.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 2 + LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExample_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            Stop.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 2 + LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [TestCase(Sport)]
    [TestCase(SportPlus)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(EnumStatePatternDriveExample option)
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            option.ToString(), Stop.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 2 + LogCountForInput * 2;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [TestCase(Sport, Eco)]
    [TestCase(Eco, Sport, SportPlus, Sport)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(params EnumStatePatternDriveExample[] option)
    {
        // act
        var readerValues = new Queue<string>(option.Select(x => x.ToString()));
        readerValues.Enqueue(Stop.ToString());

        var expectedReaderCount = readerValues.Count;
        var expectedLogCount = 2 + LogCountForInput * (option.Length + 1);

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly AbstractExample sut = new StatePatternDriveExample();
}