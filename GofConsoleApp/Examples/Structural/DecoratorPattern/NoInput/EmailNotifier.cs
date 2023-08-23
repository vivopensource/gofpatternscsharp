using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;

internal class EmailNotifier : INotifier
{
    private readonly IConsoleLogger logger;

    public EmailNotifier(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute()
    {
        logger.LogInformation("Email-Notifier executed.");
    }
}