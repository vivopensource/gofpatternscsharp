namespace GofConsoleApp.Examples.Behavioral.CorPattern.InputWithOutputComponents;

internal class ResponsibilityFoo : AbstractResponsibility
{
    internal ResponsibilityFoo() : base(nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}