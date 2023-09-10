using GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern;

internal class DecoratorPatternExampleNoInput : AbstractExample
{
    protected override void Execute()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        smsNotifier.Execute();
    }
}