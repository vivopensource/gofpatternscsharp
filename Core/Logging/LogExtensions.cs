using Microsoft.Extensions.Logging;

namespace Core.Logging;

internal static class LogExtensions
{
    public static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });

    internal static void Dispose(this ILoggerFactory factory, int waitTime = 0)
    {
        factory.Dispose();

        if (waitTime > 0)
            Thread.Sleep(100);
    }
}