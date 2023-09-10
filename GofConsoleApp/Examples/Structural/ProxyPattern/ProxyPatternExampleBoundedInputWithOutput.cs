using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;
using static GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput.EnumUserType;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

internal class ProxyPatternExampleBoundedInputWithOutput : AbstractExample
{
    protected override void Execute()
    {
        Logger.LogOptions("user types", new[] { Admin, Standard, Guest });

        var proxy = CreateProxy();

        if (proxy is null)
            return;

        Logger.LogOptions("operation commands", proxy.BoundedInputs.ToList());

        ExecuteUserInterface(proxy);
    }

    private IUserInterfaceProxy? CreateProxy()
    {
        var input = AcceptInputEnum(Invalid, "user type");

        if (input.Equals(Invalid))
            return null;

        var typeUserInterface = input switch
        {
            Admin => typeof(UserInterfaceProxyAdmin),
            Standard => typeof(UserInterfaceProxyStandard),
            _ => typeof(UserInterfaceProxyGuest)
        };

        var proxyUserInterface = (IUserInterfaceProxy)Activator.CreateInstance(typeUserInterface, new UserInterface())!;
        return proxyUserInterface;
    }

    private void ExecuteUserInterface(IUserInterface proxy)
    {
        while (true)
        {
            var input = AcceptInputEnum(EnumOperationOption.Invalid, "operation command");

            if (input.Equals(EnumOperationOption.Invalid))
            {
                Logger.Log($"Quitting due to user input: {input}");
                return;
            }

            var commandOutput = proxy.Process(input);

            Logger.Log(commandOutput);
        }
    }
}