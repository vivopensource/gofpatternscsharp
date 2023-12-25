namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentExample.Strategies;

internal class CreditCardPaymentStrategy : IPaymentStrategy
{
    private decimal limit;

    public CreditCardPaymentStrategy(decimal limit) => this.limit = limit;

    public bool Execute(decimal input)
    {
        if (limit - input < 0)
            return false;

        limit -= input;
        return true;
    }

    public string Name => "Credit Card";
}