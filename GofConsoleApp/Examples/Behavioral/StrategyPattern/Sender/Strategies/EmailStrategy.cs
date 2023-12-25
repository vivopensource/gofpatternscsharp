using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StrategyPattern.Sender.Strategies;

internal class EmailStrategy : ISenderStrategy
{
    private readonly IConsoleLogger logger;

    public EmailStrategy(IConsoleLogger logger) => this.logger = logger;

    public void Execute(string input) => logger.Log($"Sending {Name}: {input}");

    public string Name => "Email";
}