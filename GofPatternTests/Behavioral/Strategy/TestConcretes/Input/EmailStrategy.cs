using Core.Console.Interfaces;
using GofPattern.Behavioral.Strategy.Interfaces;

namespace GofPatternTests.Behavioral.Strategy.TestConcretes.Input;

internal class EmailStrategy : IStrategy<string>
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