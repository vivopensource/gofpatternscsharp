using GofConsoleApp.Examples.Structural.ProxyPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class ProxyPatternUserInterfaceExampleBoundedInputTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            EnumUserType.Admin.ToString(),
            EnumOperationOption.Mkdir.ToString(),
            EnumOperationOption.Create.ToString(),
            EnumOperationOption.Remove.ToString(),
            "Quit program"
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 16;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new ProxyPatternUserInterfaceExampleBoundedInput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfOutOfBoundedInput_ThrowsException()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            EnumUserType.Standard.ToString(),
            EnumOperationOption.Read.ToString(),
            EnumOperationOption.Create.ToString(),
            EnumOperationOption.Remove.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 12;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new ProxyPatternUserInterfaceExampleBoundedInput();

        // act
        Assert.Throws<ArgumentException>(() => example.Execute(MockConsoleLogger.Object, MockInputReader.Object));

        // assert
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExampleIfOutOfBoundedInput2_ThrowsException()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            EnumUserType.Guest.ToString(),
            EnumOperationOption.Read.ToString(),
            EnumOperationOption.Create.ToString()
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 9;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new ProxyPatternUserInterfaceExampleBoundedInput();

        // act
        Assert.Throws<ArgumentException>(() => example.Execute(MockConsoleLogger.Object, MockInputReader.Object));

        // assert
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void Execute_QuitsExample_ReturnsFalse()
    {
        // arrange
        var readerValues = new Queue<string>(new[] { "Quit program" });

        var expectedReaderCount = readerValues.Count;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult =
            new ProxyPatternUserInterfaceExampleBoundedInput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
    }
}