using Core.Console;
using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibility
{
    public ResponsibilityFoo(IConsoleLogger logger) : base(logger, nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}