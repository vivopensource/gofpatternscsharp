namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal class UserInterface : IUserInterface
{
    public string Process(EnumOperationOption input)
    {
        return $"'{input}' executed successfully.";
    }
}