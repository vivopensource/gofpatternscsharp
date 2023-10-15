using GofPattern.Behavioral.Strategy.Interfaces;

namespace GofPatternTests.Behavioral.Strategy.TestConcretes.Output;

internal class DebitCardPaymentStrategy : IStrategy<decimal, bool>
{
    private readonly decimal balance;

    public DebitCardPaymentStrategy(decimal balance)
    {
        this.balance = balance;
    }

    public bool Execute(decimal input)
    {
        return balance - input >= 0;
    }
}