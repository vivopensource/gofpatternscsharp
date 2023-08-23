using Core.Console;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    public void Execute()
    {
        Execute(new ConsoleLogger());

        Thread.Sleep(100);
    }

    public bool Execute(ConsoleLogger logger)
    {
        using var logFactory = ConsoleExtensions.GetLoggerFactory();

        logger.Logger = logFactory.CreateLogger(string.Empty);

        Logger = logger;

        Steps();

        return true;
    }

    protected abstract void Steps();

    protected ConsoleLogger Logger { get; private set; } =
        new(ConsoleExtensions.GetLoggerFactory().CreateLogger(string.Empty));
}