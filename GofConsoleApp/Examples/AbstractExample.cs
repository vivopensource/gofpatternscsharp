using Core.Console;
using Core.Console.Interfaces;
using Core.Extensions;
using GofConsoleApp.Examples.ExecutionHelpers;

namespace GofConsoleApp.Examples;

internal abstract class AbstractExample
{
    protected IConsoleLogger Logger { get; private set; } =
        new ConsoleLogger(ConsoleExtensions.GetLoggerFactory().CreateLogger(string.Empty));

    protected IInputReader InputReader { get; private set; } = new InputReader(Console.In);

    public bool Execute(IConsoleLogger logger, IInputReader reader)
    {
        Logger = logger;
        InputReader = reader;

        return Execute();
    }

    protected TEnum AcceptInputEnum<TEnum>(TEnum defaultValue, string identifier)
    {
        Logger.Log($"Please provide the {identifier}...");

        var input = InputReader.AcceptInputEnum(defaultValue);

        Logger.Log($"Selected {identifier} is {input}");

        return input;
    }

    protected TEnum AcceptInputEnum<TEnum>(TEnum defaultValue, string identifier, TEnum skipOptionFromPrinting)
    {
        var enums = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToHashSet();
        enums.Remove(skipOptionFromPrinting);

        var message = $"{identifier} from options ({string.Join( ",", enums)})";

        return AcceptInputEnum(defaultValue, message);
    }

    protected string AcceptInputString(string identifier)
    {
        if (!string.IsNullOrWhiteSpace(identifier))
            Logger.Log($"Please enter the {identifier}...");

        var input = InputReader.AcceptInput();

        Logger.Log($"Provided {identifier} is {input}");

        return input;
    }

    protected EnumYesNo AcceptInputYesNo(string identifier = "")
    {
        if (!string.IsNullOrWhiteSpace(identifier))
            Logger.Log($"Please enter the {identifier} (Yes/No)...");

        var input = InputReader.AcceptInput();

        // Logger.Log($"Provided {identifier} is {input}");

        return input.ToEnum(EnumYesNo.No);
    }

    protected abstract bool Execute();


    /*
    protected int AcceptInputInt(string identifier)
    {
        if (!string.IsNullOrWhiteSpace(identifier))
            Logger.Log($"Please enter the {identifier}...");

        try
        {
            var input = InputReader.AcceptInputInt();
            Logger.Log($"Provided {identifier} is {input}");
            return input;
        }
        catch (Exception)
        {
            Logger.Log($"Provided {identifier} is invalid");
            throw;
        }
    }
    */
}