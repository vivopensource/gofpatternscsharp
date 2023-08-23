using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input.Responsibilities;

internal class ResponsibilityBar : AbstractResponsibility
{
    public ResponsibilityBar(IConsoleLogger logger) : base(logger, nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}