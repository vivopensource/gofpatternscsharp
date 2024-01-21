using GofConsoleApp.Examples;
using GofConsoleApp.Examples.Behavioral.ObserverPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.ObserverPattern;

[TestFixture]
[TestOf(typeof(ObserverPatternExample))]
internal class ObserverPatternExampleTests : BaseTest
{
    private const int LogCountForInput = 5;

    [Test]
    public void Execute_QuitsExample_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            "Petrol price is at all time high.", "Germany won Fifa WorldCup.", "Freezing conditions grip Europe", "quit"
        });

        var expectedReaderCount = readerValues.Count;
        var expectedLogCount = 3 + (expectedReaderCount - 1) * LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly BaseExample sut = new ObserverPatternExample();
}