using GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.Strategies;
using GofPatterns.Behavioral.StrategyPattern;
using GofPatterns.Behavioral.StrategyPattern.Exception;
using GofPatterns.Behavioral.StrategyPattern.Interfaces;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.StrategyPattern;

[TestFixture]
internal class StrategyContextWithOutputTests
{
    [Test]
    public void ConstructorStrategy_AssignsStrategy()
    {
        // arrange
        var creditCardPayment = new CreditCardPaymentStrategy(10.00m);

        // act
        var actualResult = new StrategyContext<decimal, bool>(creditCardPayment).Strategy;

        // assert
        Assert.That(actualResult, Is.Not.Null);
    }

    [Test]
    public void SetStrategy_AssignsStrategy()
    {
        // arrange
        const decimal givenLimit = 10.00m;
        var creditCardPayment = new CreditCardPaymentStrategy(givenLimit);

        // act
        sut.SetStrategy(creditCardPayment);

        // assert
        Assert.That(sut.Strategy, Is.Not.Null);
    }

    [Test]
    public void ExecuteStrategy_IfStrategyAssignNotAssigned_ThrowsException()
    {
        // act - assert
        Assert.Throws<MissingStrategyException>(() => sut.ExecuteStrategy(0));
    }

    [TestCase(10, 2, true)]
    [TestCase(10, 11, false)]
    public void ExecuteStrategy_RunsUnderlyingStrategy(decimal givenLimit, decimal paymentInput, bool expectedResult)
    {
        // arrange
        var creditCardPayment = new CreditCardPaymentStrategy(givenLimit);
        sut.SetStrategy(creditCardPayment);

        // act
        var actualResult = sut.ExecuteStrategy(paymentInput);

        // assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ExecuteStrategy_RunsLatestUnderlyingStrategy()
    {
        // arrange
        const int givenLimit = 10;
        var creditCardPayment = new CreditCardPaymentStrategy(givenLimit);
        sut.SetStrategy(creditCardPayment);

        const int givenBalance = 20;
        var debitCardPayment = new DebitCardPaymentStrategy(givenBalance);
        sut.SetStrategy(debitCardPayment);

        const int paymentInput = 12;

        // act
        var actualResult = sut.ExecuteStrategy(paymentInput);

        // assert
        Assert.That(actualResult, Is.True);
        Assert.That(sut.Strategy, Is.TypeOf<DebitCardPaymentStrategy>());
    }

    private readonly IStrategyContext<decimal, bool> sut = new StrategyContext<decimal, bool>();
}