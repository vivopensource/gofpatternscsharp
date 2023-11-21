using GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Input;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.StrategyContexts;
using GofPattern.Behavioral.StrategyPattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.Enums.EnumSendingOptions;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern;

internal class StrategyPatternSenderExample : AbstractExample
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