namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputWithOutputComponents;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    internal ResponsibilityFooBar() : base(nameof(ResponsibilityFooBar)) { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}