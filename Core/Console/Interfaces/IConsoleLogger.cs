using Microsoft.Extensions.Logging;

namespace Core.Console.Interfaces;

internal interface IConsoleLogger
{
    void Log(string info);

    ILogger BaseLogger { get; }
}