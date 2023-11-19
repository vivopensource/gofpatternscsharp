namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Output;

internal class CreditCardPaymentStrategy : IPaymentStrategy
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