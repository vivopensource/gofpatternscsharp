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
        BaseLogger.LogInformation("{Info}", info);
    }

    public virtual void Log(string message, object obj)
    {
        BaseLogger.LogInformation("{Message}: {Obj}", message, obj);
    }

    public bool LogAndReturnTrue(string info)
    {
        Log(info);
        return true;
    }

    public bool LogAndReturnFalse(string info)
    {
        Log(info);
        return false;
    }

    public ILogger BaseLogger { get; set; }
}