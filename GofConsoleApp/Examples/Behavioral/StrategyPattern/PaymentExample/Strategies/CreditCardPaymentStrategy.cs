namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentExample.Strategies;

internal class CreditCardPaymentStrategy : IPaymentStrategy
{
    private readonly decimal limit;

    public CreditCardPaymentStrategy(decimal limit)
    {
        this.limit = limit;
    }

    public bool Execute(decimal input)
    {
        return input > 0 && limit - input >= 0;
    }
}