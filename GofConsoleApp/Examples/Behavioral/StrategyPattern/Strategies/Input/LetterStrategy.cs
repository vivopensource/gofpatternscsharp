using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Strategies.Input;

internal class LetterStrategy : ISenderStrategy
{
    private readonly IConsoleLogger logger;

    public LetterStrategy(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute(string input)
    {
        logger.Log($"Sending Letter: {input}");
    }
}