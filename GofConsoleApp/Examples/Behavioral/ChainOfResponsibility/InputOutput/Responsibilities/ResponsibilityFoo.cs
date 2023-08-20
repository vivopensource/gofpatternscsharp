namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibility
{
    internal ResponsibilityFoo() : base(nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}