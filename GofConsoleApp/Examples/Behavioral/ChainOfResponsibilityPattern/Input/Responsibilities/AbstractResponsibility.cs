using Core.Console.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

internal abstract class AbstractResponsibility : IResponsibility<string>
{
    private readonly IConsoleLogger logger;
    private readonly string name;

    protected AbstractResponsibility(IConsoleLogger logger, string name)
    {
        this.logger = logger;
        this.name = name;
    }

    public abstract bool IsResponsible(string input);

    public void Handle(string input)
    {
        logger.LogInformation($"Handled '{input}' by '{name}'");
    }
}