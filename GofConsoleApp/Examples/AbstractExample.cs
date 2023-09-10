using Core.Console;
using Core.Console.Interfaces;
using Core.Extensions;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    public bool Execute(IConsoleLogger logger, IInputReader reader)
    {
        Logger = logger;
        InputReader = reader;

        Execute();

        return true;
    }

    protected TEnum AcceptInputEnum<TEnum>(TEnum defaultValue, string identifier = "")
    {
        if (!string.IsNullOrWhiteSpace(identifier))
            Logger.Log($"Please enter the {identifier}...");

        var input = InputReader.AcceptInput();

        Logger.Log($"Selected {identifier} is {input}");

        return input.ToEnum(defaultValue);
    }

    protected abstract void Execute();

    protected IConsoleLogger Logger { get; private set; } =
        new ConsoleLogger(ConsoleExtensions.GetLoggerFactory().CreateLogger(string.Empty));

    protected IInputReader InputReader { get; private set; } = new InputReader(Console.In);
}