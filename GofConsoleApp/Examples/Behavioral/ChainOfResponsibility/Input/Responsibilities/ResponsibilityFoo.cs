using Core.Console;
using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibility
{
    public ResponsibilityFoo(IConsoleLogger logger) : base(logger, nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}