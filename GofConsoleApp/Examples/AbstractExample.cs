using Core.Console;
using Core.Console.Interfaces;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    public bool Execute(IConsoleLogger logger, IInputReader reader)
    {
        Logger = logger;
        InputReader = reader;

        Steps();

        return true;
    }

    protected abstract void Steps();

    protected IConsoleLogger Logger { get; private set; } =
        new ConsoleLogger(ConsoleExtensions.GetLoggerFactory().CreateLogger(string.Empty));

    protected IInputReader InputReader { get; private set; } = new InputReader(Console.In);
}