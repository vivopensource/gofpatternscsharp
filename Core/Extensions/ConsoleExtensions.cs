using System.Text;
using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Extensions;

internal static class ConsoleExtensions
{
    public static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });

    public static void LogOptions<T>(this IConsoleLogger logger, string identifier, IEnumerable<T> options)
    {
        var message = new StringBuilder($"Please enter from following {identifier}: ");

        var i = 0;
        foreach (var option in options)
            message.Append($"\n {++i}. {option} ");

        logger.Log(message.ToString());
    }

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
}