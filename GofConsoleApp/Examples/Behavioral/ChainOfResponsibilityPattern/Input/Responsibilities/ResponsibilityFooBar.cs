using Core.Console;
using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    public ResponsibilityFooBar(IConsoleLogger logger) : base(logger, nameof(ResponsibilityFooBar)) { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}