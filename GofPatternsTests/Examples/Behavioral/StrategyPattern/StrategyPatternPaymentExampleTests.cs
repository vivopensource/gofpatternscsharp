using GofConsoleApp.Examples;
using GofConsoleApp.Examples.Behavioral.StrategyPattern;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents;
using Moq;
using NUnit.Framework;
using static System.Globalization.CultureInfo;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.EnumPaymentOptions;

namespace GofPatternsTests.Examples.Behavioral.StrategyPattern;

[TestFixture]
internal class StrategyPatternPaymentExampleTests : BaseTest
{
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

    [TestCase(Debit, 12.2, true)]
    [TestCase(Debit, 2800.6, false)]
    [TestCase(Credit, 13.3, true)]
    [TestCase(Credit, 1100.10, false)]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue(EnumPaymentOptions option, decimal amount,
        bool expectedResult)
    {
        // act
        var readerValues = new Queue<string>(new[]
        {
            option.ToString(), amount.ToString(InvariantCulture)
        });

        var expectedReaderCount = readerValues.Count;
        const int expectedLogCount = 6;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedReaderCount));
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly BaseExample sut = new StrategyPatternPaymentExample();
}