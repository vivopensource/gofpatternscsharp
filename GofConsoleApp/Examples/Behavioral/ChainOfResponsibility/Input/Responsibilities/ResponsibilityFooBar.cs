using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    public ResponsibilityFooBar(ICustomLogger log) : base(log, nameof(ResponsibilityFooBar)) { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}