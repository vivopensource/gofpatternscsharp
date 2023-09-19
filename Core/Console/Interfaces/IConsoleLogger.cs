using Microsoft.Extensions.Logging;

namespace Core.Console.Interfaces;

internal interface IConsoleLogger
{
    void Log(string info);

    bool LogAndReturn(string info, bool returnFlag);

    ILogger BaseLogger { get; }
}