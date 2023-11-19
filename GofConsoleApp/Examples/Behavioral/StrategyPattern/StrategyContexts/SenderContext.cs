using GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Input;
using GofPattern.Behavioral.StrategyPattern;
using GofPattern.Behavioral.StrategyPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.StrategyContexts;

internal class SenderContext
{
    private readonly IStrategyContext<string> strategyContext = new StrategyContext<string>();

    public void AssignSenderMethod(ISenderStrategy strategy)
    {
        strategyContext.SetStrategy(strategy);
    }

    public void Send(string message)
    {
        strategyContext.ExecuteStrategy(message);
    }
}