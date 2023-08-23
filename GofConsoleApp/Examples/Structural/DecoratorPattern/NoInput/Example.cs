namespace GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;

internal class Example : AbstractExample
{
    protected override void Steps()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        smsNotifier.Execute();
    }
}