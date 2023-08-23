namespace GofConsoleApp.Examples;

// ReSharper disable MemberCanBePrivate.Global
internal static class PatternOptions
{
    internal const string ChainOfResponsibilityPatternOption = "21";
    internal const string CommandPatternOption = "22";

    internal static readonly IDictionary<string, PatternMap> Patterns = new Dictionary<string, PatternMap>
    {
        {
            ChainOfResponsibilityPatternOption,
            new PatternMap("Chain Of Responsibility Pattern >> Input",
                new Behavioral.ChainOfResponsibilityPattern.Input.Example())
        },

        {
            "21.2", new PatternMap("Chain Of Responsibility Pattern >> Input & Output",
                new Behavioral.ChainOfResponsibilityPattern.InputOutput.Example())
        },

        {
            CommandPatternOption, new PatternMap("Command Pattern", new Behavioral.CommandPattern.Example())
        }
    };
}