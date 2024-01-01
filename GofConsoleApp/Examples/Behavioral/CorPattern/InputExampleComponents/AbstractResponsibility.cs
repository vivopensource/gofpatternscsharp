using Core.Console.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal abstract class AbstractResponsibility : IResponsibility<string>
{
    private readonly IConsoleLogger logger;

    protected AbstractResponsibility(IConsoleLogger logger, string name)
    {
        this.logger = logger;
        Name = name;
    }

    public abstract bool IsResponsible(string input);

    public void Handle(string input)
    {
        logger.Log($"Handled '{input}' by '{Name}'");
    }

    public string Name { get; }
}