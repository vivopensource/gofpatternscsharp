namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output.Responsibilities;

internal class ResponsibilityBar : AbstractResponsibilityInputOutput
{
    internal ResponsibilityBar() : base(nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}