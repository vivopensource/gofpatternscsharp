using Microsoft.Extensions.Logging;

namespace Core.Console;

internal static class ConsoleExtensions
{
    public static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });
}