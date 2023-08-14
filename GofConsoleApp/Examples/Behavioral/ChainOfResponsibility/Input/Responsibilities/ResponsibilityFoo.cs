using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityFoo : AbstractResponsibilityInput
{
    internal ResponsibilityFoo(ICustomLogger log) : base(log, nameof(ResponsibilityFoo)) { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}