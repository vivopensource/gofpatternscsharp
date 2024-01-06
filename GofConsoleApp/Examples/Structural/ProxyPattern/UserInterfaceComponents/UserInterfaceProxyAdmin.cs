using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal class UserInterfaceProxyAdmin : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyAdmin(IUserInterface userInterface) :
        base(userInterface, new[] { Read, Create, Mkdir, Remove, Rmdir }) { }
}