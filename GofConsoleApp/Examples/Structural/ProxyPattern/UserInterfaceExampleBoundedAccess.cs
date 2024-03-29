﻿using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;
using static GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents.EnumUserType;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

internal class UserInterfaceExampleBoundedAccess : BaseExample
{
    protected override bool Execute()
    {
        Logger.Log("user types", new[] { Admin, Standard, Guest });

        var input = AcceptInputEnum(Invalid, "user type");

        if (input.Equals(Invalid))
            return false;

        IUserInterface userInterface = new UserInterface();

        IUserInterfaceProxy proxy = input switch
        {
            Admin => new UserInterfaceProxyAdmin(userInterface),
            Standard => new UserInterfaceProxyStandard(userInterface),
            _ => new UserInterfaceProxyGuest(userInterface)
        };

        Logger.Log("operation commands", proxy.BoundedInputs.ToList());

        ExecuteUserInterface(proxy);

        return true;
    }

    private void ExecuteUserInterface(IUserInterface userInterface)
    {
        while (true)
        {
            var input = AcceptInputEnum(EnumOperationOption.Invalid, "operation command");

            if (input.Equals(EnumOperationOption.Invalid))
            {
                Logger.Log($"Quitting due to user input: {input}");
                return;
            }

            var commandOutput = userInterface.Process(input);

            Logger.Log(commandOutput);
        }
    }
}