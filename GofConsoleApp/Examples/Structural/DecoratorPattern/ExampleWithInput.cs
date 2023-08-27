namespace GofConsoleApp.Examples.Structural.DecoratorPattern.Input;

internal class ExampleWithInput : AbstractExample
{
    protected override void Steps()
    {
        var emailNotifier = new EmailNotifier(Logger);
        var smsNotifier = new SmsNotifier(emailNotifier, Logger);

        var input = InputReader.AcceptInput();
        
        smsNotifier.Execute(input);
    }
}