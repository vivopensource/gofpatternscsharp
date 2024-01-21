using GofConsoleApp.Examples.Behavioral.ObserverPattern;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.ObserverPattern.Components.EnumTopic;

namespace GofPatternsTests.Examples.Behavioral.ObserverPattern;

[TestFixture]
[TestOf(typeof(ObserverPatternExampleWithCategory))]
internal class ObserverPatternExampleWithCategoryTest : BaseTest
{

    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            Sports.ToString(), "AC Milan has won.",
            Weather.ToString(), "Freezing conditions has gripped Europe.",
            Politics.ToString(), "German elections are set in next month.",
            Holidays.ToString(), "German old cities are becoming famous tourist attractions.",
            Quit.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 29;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new ObserverPatternExampleWithCategory().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }
}