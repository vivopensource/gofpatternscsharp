using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Console;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
internal class ConsoleLogger : IConsoleLogger
{
    public ConsoleLogger(ILogger logger)
    {
        Logger = logger;
    }

    public virtual void Log(string info)
    {
        Logger.LogInformation("Message: {Info}",info);
    }

    public ILogger Logger { get; set; }
}