using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityBar : AbstractResponsibility
{
    public ResponsibilityBar(IConsoleLogger logger) : base(logger, nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}