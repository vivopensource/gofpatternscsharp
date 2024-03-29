using GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents.Strategies;
using GofPatterns.Behavioral.StrategyPattern;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents.EnumSendingOptions;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern;

internal class StrategyPatternSenderExample : BaseExample
{
    protected override bool Execute()
    {
        var inputOption = AcceptInputEnum(Invalid, "sending method", Invalid);

        ISenderStrategy strategy;

        if (inputOption == Email)
            strategy = new EmailStrategy(Logger);
        else if (inputOption == Letter)
            strategy = new LetterStrategy(Logger);
        else
            return Logger.LogAndReturnFalse($"Quitting program due to input: {inputOption}.");

        senderContext.SetStrategy(strategy);

        var message = AcceptInputString("message to send");
        senderContext.ExecuteStrategy(message);

        return true;
    }

    private readonly IStrategyContext<string> senderContext = new SenderStrategyContext();
}