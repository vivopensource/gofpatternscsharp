using Core.Console.Interfaces;
using GofConsoleApp.Examples.ExecutionHelpers;

namespace GofConsoleApp.Examples;

internal static class Execution
{
    public static bool Run(IConsoleLogger logger, IInputReader reader)
    {
        var example = GetPatternInput(logger, reader);

        var result = example.Execute(logger, reader);

        Thread.Sleep(100);

        return result;
    }

    private static AbstractExample GetPatternInput(IConsoleLogger logger, IInputReader reader)
    {
        while (true)
        {
            logger.Log("Please provide input from the following options.");

            PrintOptions(logger);

            var input = reader.AcceptInput().Trim();

            if (!PatternOptions.Patterns.TryGetValue(input, out var pattern))
                continue;

            logger.Log($"Valid input: #{input} [{pattern.Name}]");

            PrintTitle(logger, pattern.Name);

            return pattern.Example;
        }
    }

    private static void PrintTitle(IConsoleLogger logger, string pattern)
    {
        var message = "\n" +
                      "---------------------------------------------------------- \n" +
                      "---------------------------------------------------------- \n" +
                      "-------------------- STARTING PATTERN -------------------- \n" +
                      "---------------------------------------------------------- \n" +
                      $" {pattern} \n" +
                      "---------------------------------------------------------- \n" +
                      "---------------------------------------------------------- ";

        logger.Log(message);
    }

    private static void PrintOptions(IConsoleLogger logger)
    {
        foreach (var pattern in PatternOptions.Patterns)
            logger.Log($"#{pattern.Key} [{pattern.Value.Name}]");
    }
}