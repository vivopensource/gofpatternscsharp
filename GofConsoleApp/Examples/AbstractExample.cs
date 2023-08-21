using Core.Console;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    public bool Execute()
    {
        using var logFactory = ConsoleExtensions.GetLoggerFactory();

        Logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));

        Steps();

        Thread.Sleep(100);

        return true;
    }

    protected abstract void Steps();

    protected ConsoleLogger Logger { get; private set; } =
        new(ConsoleExtensions.GetLoggerFactory().CreateLogger(string.Empty));
}