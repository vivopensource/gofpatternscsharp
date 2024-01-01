using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents;

internal class ResponsibilityBar : AbstractResponsibility
{
    public ResponsibilityBar(IConsoleLogger logger) : base(logger, "BarCoR") { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}