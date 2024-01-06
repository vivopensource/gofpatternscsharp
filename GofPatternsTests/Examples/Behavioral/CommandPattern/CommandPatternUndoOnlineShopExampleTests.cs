using GofConsoleApp.Examples.Behavioral.CommandPattern;
using GofConsoleApp.Examples.ExecutionHelpers;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents.EnumProductOperationOptions;

namespace GofPatternsTests.Examples.Behavioral.CommandPattern;

[TestFixture]
internal class CommandPatternUndoOnlineShopExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            Purchase.ToString(), "Laptop", EnumYesNo.Yes.ToString(),
            Return.ToString(), "Laptop", EnumYesNo.Yes.ToString(),
            Purchase.ToString(), "Monitors", EnumYesNo.No.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 20;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoOnlineShopExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

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
            "ThisIsInvalid"
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 3;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoOnlineShopExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }
}