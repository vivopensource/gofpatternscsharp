using GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentExample;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Output;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.StrategyContexts;
using GofPattern.Behavioral.StrategyPattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.PaymentExample.EnumPaymentOptions;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern;

internal class StrategyPatternPaymentExample : AbstractExample
{
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

        senderContext.SetStrategy(strategy);

        var message = AcceptInputDecimal("payment amount");
        var paymentResult = senderContext.ExecuteStrategy(message);

        return PrintPaymentResult(paymentResult);
    }

    private bool PrintPaymentResult(bool paymentResult)
    {
        if (paymentResult)
            return Logger.LogAndReturnTrue("Payment successful.");

        return Logger.LogAndReturnFalse("Payment unsuccessful.");
    }

    private readonly IStrategyContext<decimal, bool> senderContext = new PaymentStrategyContext();
}