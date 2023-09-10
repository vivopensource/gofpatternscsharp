using GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;
using GofPattern.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput.EnumOperationOption;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;

internal class UserInterfaceProxyStandard : ProxyBoundedInput<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyStandard(IUserInterface userInterface) : base(userInterface, new[] { Read, Create, Mkdir }) { }
}