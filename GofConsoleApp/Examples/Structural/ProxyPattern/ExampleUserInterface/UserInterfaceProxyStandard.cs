using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;
using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal class UserInterfaceProxyStandard : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyStandard(IUserInterface userInterface) : base(userInterface, new[] { Read, Create, Mkdir }) { }
}