using GofConsoleApp.Examples.Structural.DecoratorPattern.NoInputExampleComponents;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern;

internal class DecoratorPatternExampleNoInput : BaseExample
{
    protected override bool Execute()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        smsNotifier.Execute();

        return true;
    }
}