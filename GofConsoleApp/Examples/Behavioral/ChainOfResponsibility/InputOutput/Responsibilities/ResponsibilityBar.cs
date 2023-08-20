namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Responsibilities;

internal class ResponsibilityBar : AbstractResponsibility
{
    internal ResponsibilityBar() : base(nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}