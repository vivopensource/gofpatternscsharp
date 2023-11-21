using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.Input;

internal class EmailNotifier : INotifier
{
    private readonly IConsoleLogger logger;

    public EmailNotifier(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute(string input)
    {
        logger.Log($"Email-Notifier executed with message: '{input}'.");
    }
}