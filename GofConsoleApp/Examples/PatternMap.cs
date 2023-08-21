namespace GofConsoleApp.Examples;

internal sealed class PatternMap
{
    public PatternMap(string name, AbstractExample instance)
    {
        Name = name;
        Instance = instance;
    }

    public string Name { get; }

    public AbstractExample Instance { get; }
}