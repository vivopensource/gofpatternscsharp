using Microsoft.Extensions.Logging;

namespace Core.Console.Interfaces;

internal interface IConsoleLogger
{
    void LogInformation(string info);

    public ILogger? Logger { get; set; }
}