using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibility
{
    public ResponsibilityFoo(ICustomLogger log) : base(log, nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}