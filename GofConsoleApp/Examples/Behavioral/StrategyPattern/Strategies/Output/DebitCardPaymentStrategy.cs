namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Output;

internal class DebitCardPaymentStrategy : IPaymentStrategy
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