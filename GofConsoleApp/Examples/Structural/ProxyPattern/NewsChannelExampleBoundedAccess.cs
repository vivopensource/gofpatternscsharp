using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents;
using static GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents.EnumNewsChannel;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

/// <summary>
/// This example uses the Bounded Input approach of Proxy Pattern.
/// It loads from the list of bounded (limited) news channels to start news broadcasting on the television.
/// </summary>
internal class NewsChannelExampleBoundedAccess : AbstractExample
{
    protected override bool Execute()
    {
        Logger.Log("new channels", new[] { Acy, Uzt, Mko });

        var input = AcceptInputEnum(Invalid, "new channels");

        if (input == Invalid)
        {
            Logger.Log($"Quitting program due to input: {input}.");
            return false;
        }

        new NewsChannelProxy(Logger).Process(input);

        return true;
    }
}