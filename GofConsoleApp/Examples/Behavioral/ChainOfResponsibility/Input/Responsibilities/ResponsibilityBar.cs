using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityBar : AbstractResponsibility
{
    public ResponsibilityBar(ICustomLogger log) : base(log, nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}