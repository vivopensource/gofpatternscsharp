using Microsoft.Extensions.Logging;

namespace Core.Logging;

internal static class LogExtensions
{
    public static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });
}