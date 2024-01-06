using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInputExampleComponents;

internal class EmailNotifier : INotifier
{
    private readonly IConsoleLogger logger;

    public EmailNotifier(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute()
    {
        logger.Log("Email-Notifier executed.");
    }
}