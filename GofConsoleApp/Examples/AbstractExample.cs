using Core.Logging;
using Microsoft.Extensions.Logging;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    public bool Execute()
    {
        using var logFactory = LogExtensions.GetLoggerFactory();

        Logger = new CustomLogger(logFactory.CreateLogger<Program>());

        Steps();

        Thread.Sleep(100);

        return true;
    }

    protected abstract void Steps();

    protected CustomLogger Logger { get; private set; } = new(LogExtensions.GetLoggerFactory().CreateLogger<Program>());
}