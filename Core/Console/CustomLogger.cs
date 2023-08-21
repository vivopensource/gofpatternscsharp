using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Console;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
internal class ConsoleLogger : IConsoleLogger
{
    private readonly ILogger logger;

    public ConsoleLogger(ILogger logger)
    {
        this.logger = logger;
    }

    public virtual void LogInformation(string info)
    {
        logger.LogInformation("Message: {Info}",info);
    }
}