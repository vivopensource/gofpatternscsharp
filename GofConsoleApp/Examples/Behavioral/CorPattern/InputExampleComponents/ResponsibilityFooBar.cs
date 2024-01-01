using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    public ResponsibilityFooBar(IConsoleLogger logger) : base(logger, "FooBarCoR") { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}