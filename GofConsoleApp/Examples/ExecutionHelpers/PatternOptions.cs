using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using GofConsoleApp.Examples.Structural.DecoratorPattern.Input;
using ExampleWithInput = GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.ExampleWithInput;

namespace GofConsoleApp.Examples.ExecutionHelpers;

// ReSharper disable MemberCanBePrivate.Global
internal static class PatternOptions
{
    internal const string DecoratorPatternOption = "11";
    internal const string DecoratorPatternOption2 = "11.2";
    internal const string ChainOfResponsibilityPatternOption = "21";
    internal const string ChainOfResponsibilityPatternOption2 = "21.2";
    internal const string CommandPatternOption = "22";

    internal static readonly IDictionary<string, PatternExampleMap> Patterns = new Dictionary<string, PatternExampleMap>
    {
        // Structural Patterns
        {
            DecoratorPatternOption,
            new PatternExampleMap("Decorator Pattern >> Input", new ExampleWithInput())
        },
        {
            DecoratorPatternOption2,
            new PatternExampleMap("Decorator Pattern >> No Input", new Structural.DecoratorPattern.NoInput.ExampleNoInput())
        },

        // Behavioral Patterns
        {
            ChainOfResponsibilityPatternOption,
            new PatternExampleMap("Chain Of Responsibility Pattern >> Input",
                new ExampleWithInput())
        },

        {
            ChainOfResponsibilityPatternOption2, new PatternExampleMap(
                "Chain Of Responsibility Pattern >> Input & Output",
                new ExampleWithInputOutput())
        },

        {
            CommandPatternOption, new PatternExampleMap("Command Pattern", new Behavioral.CommandPattern.Example())
        }
    };
}