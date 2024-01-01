using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;
using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;
using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal class UserInterfaceProxyGuest : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyGuest(IUserInterface userInterface) : base(userInterface, new[] { Read }) { }
}