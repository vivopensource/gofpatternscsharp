using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output.Responsibilities;

internal abstract class AbstractResponsibilityInputOutput : IResponsibility<string, string>
{
    private readonly string name;

    internal AbstractResponsibilityInputOutput(string name)
    {
        this.name = name;
    }

    public abstract bool IsResponsible(string input);

    public string Handle(string input)
    {
        return $"Handling '{input}' by '{name}'";
    }
}