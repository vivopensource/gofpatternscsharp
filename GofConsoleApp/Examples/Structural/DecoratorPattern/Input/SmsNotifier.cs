using Core.Console.Interfaces;
using GofPattern.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.Input;

internal class SmsNotifier : BaseDecorator<INotifier, string>
{
    private readonly IConsoleLogger logger;

    public SmsNotifier(INotifier notifier, IConsoleLogger logger) : base(notifier)
    {
        this.logger = logger;
    }

    public override void Execute(string input)
    {
        base.Execute(input);

        logger.LogInformation($"Sms-Notifier executed with message: '{input}'");
    }
}