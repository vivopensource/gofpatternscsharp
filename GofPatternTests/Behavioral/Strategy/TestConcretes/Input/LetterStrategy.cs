using Core.Console.Interfaces;
using GofPattern.Behavioral.Strategy.Interfaces;

namespace GofPatternTests.Behavioral.Strategy.TestConcretes.Input;

internal class LetterStrategy : IStrategy<string>
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