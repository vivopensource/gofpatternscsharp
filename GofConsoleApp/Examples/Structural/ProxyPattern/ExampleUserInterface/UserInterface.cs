using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal class UserInterface : IUserInterface
{
    public string Process(EnumOperationOption input)
    {
        return $"'{input}' executed successfully.";
    }
}