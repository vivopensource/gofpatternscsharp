using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputWithOutputComponents;

internal abstract class AbstractResponsibility : IResponsibility<string, string>
{
    private readonly string name;

    private protected AbstractResponsibility(string name)
    {
        this.name = name;
    }

    public abstract bool IsResponsible(string input);

    public string Handle(string input)
    {
        return $"Handling '{input}' by '{name}'";
    }
}