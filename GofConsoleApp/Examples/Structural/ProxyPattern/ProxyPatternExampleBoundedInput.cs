using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput;
using static GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput.EnumNewsChannel;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

/// <summary>
/// This example uses the Bounded Input approach of Proxy Pattern.
/// It loads from the list of bounded (limited) news channels
/// to start news broadcasting on the television.
/// </summary>
internal class ProxyPatternExampleBoundedInput : AbstractExample
{
    protected override bool Execute()
    {
        Logger.LogOptions("new channels", new[] { Acy, Uzt, Mko });

        var proxy = new NewsTelevisionProxy(Logger);

        return ExecuteNewsBroadcast(proxy);
    }

    private bool ExecuteNewsBroadcast(INewsTelevision proxy)
    {
        var input = AcceptInputEnum(Invalid, "new channels");

        if (input == Invalid)
        {
            Logger.Log($"Quitting program due to input: {input}.");
            return false;
        }

        proxy.Process(input);
        return true;
    }
}