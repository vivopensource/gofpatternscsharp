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

        var message = $"{identifier} from options ({string.Join(",", enums)})";

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

        return input.ToEnum(EnumYesNo.No);
    }

    protected decimal AcceptInputDecimal(string identifier)
    {
        if (!string.IsNullOrWhiteSpace(identifier))
            Logger.Log($"Please enter the {identifier}...");

        try
        {
            var input = InputReader.AcceptInputDecimal();
            Logger.Log($"Provided {identifier} is {input}");
            return input;
        }
        catch (Exception)
        {
            Logger.Log($"Provided {identifier} is invalid");
            throw;
        }
    }

    protected bool IsInvalidOrQuit<TEnum>(TEnum input, TEnum invalid, TEnum quit, out bool output)
    {

        if (input!.Equals(invalid))
        {
            output = false;
            return Logger.LogAndReturnTrue($"Quitting program due to input: {input}.");
        }

        output = true;

        if (input.Equals(quit))
            return Logger.LogAndReturnTrue("Quitting program.");

        return false;
    }

    protected abstract bool Execute();
}