namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibilityInputOutput
{
    internal ResponsibilityFoo() : base(nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}