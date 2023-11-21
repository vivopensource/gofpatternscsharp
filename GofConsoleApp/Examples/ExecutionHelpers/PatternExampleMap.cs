namespace GofConsoleApp.Examples.ExecutionHelpers;

internal sealed class PatternExampleMap
{
    public PatternExampleMap(string name, AbstractExample example)
    {
        Name = name;
        Example = example;
    }

    public string Name { get; }

    public AbstractExample Example { get; }
}