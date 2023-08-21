using Core.Console;
using Core.Console.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal abstract class AbstractResponsibility : IResponsibility<string>
{
    private readonly IConsoleLogger log;
    private readonly string name;

    protected AbstractResponsibility(IConsoleLogger log, string name)
    {
        this.log = log;
        this.name = name;
    }

    public abstract bool IsResponsible(string input);

    public void Handle(string input)
    {
        log.LogInformation($"Handled '{input}' by '{name}'");
    }
}