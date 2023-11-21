using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Input;

internal class EmailStrategy : ISenderStrategy
{
    private readonly IConsoleLogger logger;

    public EmailStrategy(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute(string input)
    {
        logger.Log($"Sending Emailing: {input}");
    }
}