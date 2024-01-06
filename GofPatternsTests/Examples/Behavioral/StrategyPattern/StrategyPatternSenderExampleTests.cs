using GofConsoleApp.Examples.Behavioral.StrategyPattern;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents.EnumSendingOptions;

namespace GofPatternsTests.Examples.Behavioral.StrategyPattern;

[TestFixture]
internal class StrategyPatternSenderExampleTests : BaseTest
{
    [TestCase(Letter)]
    [TestCase(Email)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(EnumSendingOptions option)
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            option.ToString(), "Test message"
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 5;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfInvalidOption_ReturnsFalse()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            Invalid.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 3;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly StrategyPatternSenderExample sut = new();
}