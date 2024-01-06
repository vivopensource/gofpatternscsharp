using Core.Console.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal class ResponsibilityBar : IResponsibility<string>
{
    private readonly IConsoleLogger logger;

    public ResponsibilityBar(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }

    public void Handle(string input)
    {
        logger.Log($"Handled '{input}' by 'BarCoR'");
    }
}