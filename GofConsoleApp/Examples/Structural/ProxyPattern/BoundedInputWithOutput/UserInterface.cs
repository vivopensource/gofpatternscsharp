namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;

internal class UserInterface : IUserInterface
{
    public string Process(EnumOperationOption input)
    {
        return $"'{input}' executed successfully.";
    }
}