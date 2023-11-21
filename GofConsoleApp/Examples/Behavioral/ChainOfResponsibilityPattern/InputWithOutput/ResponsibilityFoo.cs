namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.InputWithOutput;

internal class ResponsibilityFoo : AbstractResponsibility
{
    internal ResponsibilityFoo() : base(nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}