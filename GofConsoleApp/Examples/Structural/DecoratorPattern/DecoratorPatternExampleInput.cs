using GofConsoleApp.Examples.Structural.DecoratorPattern.Input;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern;

internal class DecoratorPatternExampleInput : AbstractExample
{
    protected override void Execute()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        Logger.Log("Please enter the notification message:");

        var input = InputReader.AcceptInput();

        smsNotifier.Execute(input);
    }
}