using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Console;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
internal class ConsoleLogger : IConsoleLogger
{
    public ConsoleLogger(ILogger logger)
    {
        BaseLogger = logger;
    }

    public virtual void Log(string info)
    {
        BaseLogger.LogInformation("Message: {Info}", info);
    }

    public ILogger BaseLogger { get; set; }
}