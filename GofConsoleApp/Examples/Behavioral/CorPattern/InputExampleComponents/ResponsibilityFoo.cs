using Core.Console.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal class ResponsibilityFoo : IResponsibility<string>
{
    private readonly IConsoleLogger logger;

    public ResponsibilityFoo(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }

    public void Handle(string input)
    {
        logger.Log($"Handled '{input}' by 'FooCoR'");
    }
}