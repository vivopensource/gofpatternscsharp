using GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;
using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;

internal class UserInterfaceProxyAdmin : ProxyBoundedInput<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyAdmin(IUserInterface userInterface) :
        base(userInterface, new[] { Read, Create, Mkdir, Remove, Rmdir }) { }
}