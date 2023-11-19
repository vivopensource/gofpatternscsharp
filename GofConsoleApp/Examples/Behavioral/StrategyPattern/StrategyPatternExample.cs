using GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Input;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.StrategyContexts;
using static GofConsoleApp.Examples.Behavioral.StrategyPattern.Enums.EnumSendingOptions;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern;

internal class StrategyPatternExample : AbstractExample
{
    protected override bool Execute()
    {
        var inputOption = AcceptInputEnum(Invalid, "sending method", Invalid);

        if (inputOption == Invalid)
            return Logger.LogAndReturn($"Quitting program due to input: {inputOption}.", false);

        ISenderStrategy strategy;

        if (inputOption == Email)
            strategy = new EmailStrategy(Logger);
        else if (inputOption == Letter)
            strategy = new LetterStrategy(Logger);
        else
            return Logger.LogAndReturn($"Quitting program due to input: {inputOption}.", false);

        var senderContext = new SenderContext();
        senderContext.AssignSenderMethod(strategy);

        var message = AcceptInputString("message to send");
        senderContext.Send(message);

        return true;
    }
}