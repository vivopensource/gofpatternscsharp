namespace GofConsoleApp.Examples;

// ReSharper disable MemberCanBePrivate.Global

internal static class PatternOptions
{
    internal const string ChainOfResponsibilityOption = "21";
    internal const string CommandOption = "22";

    internal static readonly IDictionary<string, PatternMap> Patterns = new Dictionary<string, PatternMap>
    {
        {
            ChainOfResponsibilityOption,
            new PatternMap("Chain Of Responsibility >> Input",
                new Behavioral.ChainOfResponsibility.Input.Example())
        },

        {
            "21.2", new PatternMap("Chain Of Responsibility >> Input & Output",
                new Behavioral.ChainOfResponsibility.InputOutput.Example())
        },

        {
            CommandOption, new PatternMap("Command", new Behavioral.CommandPattern.Example())
        }
    };
}