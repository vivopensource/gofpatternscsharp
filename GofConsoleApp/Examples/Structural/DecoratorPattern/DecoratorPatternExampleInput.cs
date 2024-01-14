using GofConsoleApp.Examples.Structural.DecoratorPattern.InputExampleComponents;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern;

internal class DecoratorPatternExampleInput : BaseExample
{
    protected override bool Execute()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        Logger.Log("Please enter the notification message:");

        var input = InputReader.AcceptInput();

        smsNotifier.Execute(input);

        return true;
    }
}