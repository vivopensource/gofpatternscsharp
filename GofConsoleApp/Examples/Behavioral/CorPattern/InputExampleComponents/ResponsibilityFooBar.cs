using Core.Console.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal class ResponsibilityFooBar : IResponsibility<string>
{
    private readonly IConsoleLogger logger;
    public ResponsibilityFooBar(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }

    public void Handle(string input)
    {
        logger.Log($"Handled '{input}' by 'FooBarCoR'");
    }
}