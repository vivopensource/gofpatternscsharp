using GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.Strategies;
using GofPatterns.Behavioral.StrategyPattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentComponents.EnumPaymentOptions;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern;

internal class StrategyPatternPaymentExample : AbstractExample
{
    private readonly IStrategyContext<decimal, bool> paymentContext = new PaymentStrategyContext();

    protected override bool Execute()
    {
        var inputOption = AcceptInputEnum(Invalid, "payment method (max 1000)", Invalid);

        IPaymentStrategy strategy;

        if (inputOption == Credit)
            strategy = new CreditCardPaymentStrategy(1000);
        else if (inputOption == Debit)
            strategy = new DebitCardPaymentStrategy(1000);
        else
            return Logger.LogAndReturnFalse($"Quitting program due to input: {inputOption}.");

        paymentContext.SetStrategy(strategy);
        Logger.Log($"Payment using '{paymentContext.Strategy!.Name}'");

        var message = AcceptInputDecimal("payment amount");
        var paymentResult = paymentContext.ExecuteStrategy(message);

        return PrintPaymentResult(paymentResult);
    }

    private bool PrintPaymentResult(bool paymentResult)
    {
        if (paymentResult)
            return Logger.LogAndReturnTrue("Payment successful.");

        return Logger.LogAndReturnFalse("Payment unsuccessful.");
    }
}