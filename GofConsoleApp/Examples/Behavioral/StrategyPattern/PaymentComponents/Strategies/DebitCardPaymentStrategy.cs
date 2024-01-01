namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.Strategies;

internal class DebitCardPaymentStrategy : IPaymentStrategy
{
    private decimal balance;

    public DebitCardPaymentStrategy(decimal balance) => this.balance = balance;

    public bool Execute(decimal input)
    {
        if (balance - input < 0)
            return false;

        balance -= input;
        return true;
    }

    public string Name => "Debit Card";
}