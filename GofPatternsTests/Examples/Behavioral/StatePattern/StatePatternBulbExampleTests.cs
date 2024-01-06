using GofConsoleApp.Examples;
using GofConsoleApp.Examples.Behavioral.StatePattern;
using GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents.EnumStatePatternBulbExample;

namespace GofPatternsTests.Examples.Behavioral.StatePattern;

[TestFixture]
internal class StatePatternBulbExampleTests : BaseTest
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
        const int expectedLogCount = 1 + LogCountForInput;

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
            Quit.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 1 + LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [TestCase(On)]
    [TestCase(Off)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(EnumStatePatternBulbExample option)
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            option.ToString(), Quit.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 1 + LogCountForInput * 2;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [TestCase(On, Off)]
    [TestCase(Off, On, On, Off)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(params EnumStatePatternBulbExample[] option)
    {
        // act
        var readerValues = new Queue<string>(option.Select(x => x.ToString()));
        readerValues.Enqueue(Quit.ToString());

        var expectedReaderCount = readerValues.Count;
        var expectedLogCount = 1 + LogCountForInput * (option.Length + 1);

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly AbstractExample sut = new StatePatternBulbExample();
}