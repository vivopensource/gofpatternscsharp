using GofConsoleApp.Examples.Behavioral.CommandPattern;
using GofConsoleApp.Examples.ExecutionHelpers;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.CommandPattern.Enums.EnumProductOperationOptions;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class CommandPatternUndoExampleTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            "Laptop", Purchase.ToString(), EnumYesNo.Yes.ToString(),
            "Laptop", Return.ToString(), EnumYesNo.Yes.ToString(),
            "Monitors", Purchase.ToString(), EnumYesNo.No.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 23;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfInvalidOption_ReturnsTrue()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            "Laptop", Invalid.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 4;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfInvalidOption_ReturnsFalse()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            "Laptop", "ThisIsInvalid"
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 4;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }
}