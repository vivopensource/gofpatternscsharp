using Core.Console.Interfaces;
using GofPatterns.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;

internal class SmsNotifier : BaseDecorator<INotifier>
{
    private readonly IConsoleLogger logger;

    public SmsNotifier(INotifier notifier, IConsoleLogger logger) : base(notifier)
    {
        this.logger = logger;
    }

    public override void Execute()
    {
        base.Execute();

        logger.Log("Sms-Notifier executed.");
    }
}