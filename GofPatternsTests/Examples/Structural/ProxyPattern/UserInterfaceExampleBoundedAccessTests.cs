﻿using GofConsoleApp.Examples.Structural.ProxyPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.ProxyPattern;

[TestFixture]
internal class UserInterfaceExampleBoundedAccessTests : BaseTest
{
    private const int LogCountForInput = 3;

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
            EnumOperationOption.Rmdir.ToString(),
            "Quit program"
        });

        var expectedReaderCount = readerValues.Count;
        var expectedLogCount = 2 + (expectedReaderCount - 1) * LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var sut = new UserInterfaceExampleBoundedAccess();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(2));
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
        var expectedLogCount = 4 + (expectedReaderCount - 2) * LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new UserInterfaceExampleBoundedAccess();

        // act
        Assert.Throws<ArgumentException>(() => example.Execute(MockConsoleLogger.Object, MockInputReader.Object));

        // assert
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(2));
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
        var expectedLogCount = 4 + (expectedReaderCount - 2) * LogCountForInput;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        var example = new UserInterfaceExampleBoundedAccess();

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
            new UserInterfaceExampleBoundedAccess().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.False);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
    }
}