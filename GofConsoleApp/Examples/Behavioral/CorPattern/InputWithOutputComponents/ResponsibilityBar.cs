namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputWithOutputComponents;

internal class ResponsibilityBar : AbstractResponsibility
{
    internal ResponsibilityBar() : base(nameof(ResponsibilityBar)) { }

    public override bool IsResponsible(string input)
    {
        return "Bar".Equals(input);
    }
}