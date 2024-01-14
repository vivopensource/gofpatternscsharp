using Microsoft.Extensions.Logging;

namespace Core.Console.Interfaces;

internal interface IConsoleLogger
{
    void Log(string info);

    void Log(string message, object obj);

    bool LogAndReturnTrue(string info);

    bool LogAndReturnFalse(string info);

    ILogger BaseLogger { get; }
}