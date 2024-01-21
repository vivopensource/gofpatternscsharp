using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Extensions;

internal static class ConsoleExtensions
{
    public static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });

    public static TEnum AcceptInputEnum<TEnum>(this IInputReader inputReader, TEnum defaultValue)
    {
        var input = inputReader.AcceptInput();

        return input.ToEnum(defaultValue);
    }

    public static decimal AcceptInputDecimal(this IInputReader inputReader)
    {
        var input = inputReader.AcceptInput();
        return decimal.Parse(input);
    }

    public static void LogInfoQuit(this IConsoleLogger logger)
    {
        logger.Log("Please provide 'quit' input in order to quit from the example.");
    }
}