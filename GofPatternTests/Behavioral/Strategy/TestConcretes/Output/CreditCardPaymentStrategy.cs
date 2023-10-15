using GofPattern.Behavioral.Strategy.Interfaces;

namespace GofPatternTests.Behavioral.Strategy.TestConcretes.Output;

internal class CreditCardPaymentStrategy : IStrategy<decimal, bool>
{
    private readonly decimal limit;

    public CreditCardPaymentStrategy(decimal limit)
    {
        this.limit = limit;
    }

    public bool Execute(decimal input)
    {
        return limit - input >= 0;
    }
}