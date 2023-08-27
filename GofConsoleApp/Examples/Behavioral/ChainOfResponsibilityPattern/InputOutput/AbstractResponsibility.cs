using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.InputOutput;

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