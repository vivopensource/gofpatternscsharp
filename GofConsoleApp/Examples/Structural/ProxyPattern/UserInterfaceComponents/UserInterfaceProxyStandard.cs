using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal class UserInterfaceProxyStandard : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyStandard(IUserInterface userInterface) : base(userInterface, new[] { Read, Create, Mkdir }) { }
}