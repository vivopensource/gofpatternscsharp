namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output.Responsibilities;

internal class ResponsibilityFooBar : AbstractResponsibilityInputOutput
{
    internal ResponsibilityFooBar() : base(nameof(ResponsibilityFooBar)) { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}