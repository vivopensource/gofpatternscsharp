using Microsoft.Extensions.Logging;

namespace Core.Console.Interfaces;

internal interface IConsoleLogger
{
    void Log(string info);

    bool LogAndReturnTrue(string info);

    bool LogAndReturnFalse(string info);

    ILogger BaseLogger { get; }
}