namespace GofConsoleApp.Examples.ExecutionHelpers;

internal sealed class PatternExampleMap
{
    public PatternExampleMap(string name, BaseExample example)
    {
        Name = name;
        Example = example;
    }

    public string Name { get; }

    public BaseExample Example { get; }
}