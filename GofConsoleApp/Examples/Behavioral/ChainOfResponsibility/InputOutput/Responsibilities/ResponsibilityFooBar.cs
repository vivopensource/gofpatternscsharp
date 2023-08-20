namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Responsibilities;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    internal ResponsibilityFooBar() : base(nameof(ResponsibilityFooBar)) { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}