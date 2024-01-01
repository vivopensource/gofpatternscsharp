using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;
using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal class UserInterfaceProxyAdmin : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyAdmin(IUserInterface userInterface) :
        base(userInterface, new[] { Read, Create, Mkdir, Remove, Rmdir }) { }
}