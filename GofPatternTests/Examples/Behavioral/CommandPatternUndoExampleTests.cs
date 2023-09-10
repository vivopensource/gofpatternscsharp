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
            "Laptop", "2", Order.ToString(),
            EnumYesNo.Yes.ToString(),
            "Laptop", "1", Return.ToString(),
            EnumYesNo.Yes.ToString(),
            "Monitors", "2", Order.ToString(),
            EnumYesNo.No.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 29;

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
            "Laptop", "2", Invalid.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 7;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new CommandPatternUndoExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfInvalidCount_ThrowsException()
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            "Laptop", "NaN"
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 4;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new CommandPatternUndoExample();

        // act
        Assert.Throws<FormatException>(() => example.Execute(MockConsoleLogger.Object, MockInputReader.Object));

        // assert
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }
}