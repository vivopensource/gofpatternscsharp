using Core.Logging;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal abstract class AbstractResponsibilityInput : IResponsibility<string>
{
    private readonly ICustomLogger log;
    private readonly string name;

    internal AbstractResponsibilityInput(ICustomLogger log, string name)
    {
        this.log = log;
        this.name = name;
    }

    public abstract bool IsResponsible(string input);

    public void Handle(string input)
    {
        log.LogInformation($"Handling '{input}' by '{name}'");
    }
}