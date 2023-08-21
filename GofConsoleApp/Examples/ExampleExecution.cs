using Core.Console;
using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;

namespace GofConsoleApp.Examples;

internal static class ExampleExecution
{
    public static bool Run(IConsoleReader reader)
    {
        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = logFactory.CreateLogger("");

        var example = UserInput(reader, logger);

        return example.Execute();
    }

    private static AbstractExample UserInput(IConsoleReader reader, ILogger logger)
    {
        while (true)
        {
            logger.LogInformation("Please provide input from the following options.");

            PrintOptions(logger);

            var input = reader.AcceptInput().Trim();

            foreach (var pattern in PatternOptions.Patterns)
                if (pattern.Key.Equals(input))
                {
                    logger.LogInformation($"Valid input: {input}");
                    return pattern.Value.Instance;
                }
        }
    }

    private static void PrintOptions(ILogger logger)
    {
        foreach (var pattern in PatternOptions.Patterns)
            logger.LogInformation($"#{pattern.Key} [{pattern.Value.Name}]");
    }
}