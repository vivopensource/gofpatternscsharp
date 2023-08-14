using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output.Responsibilities;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output;

internal class ChainOfResponsibilityExampleInputOutput : AbstractExample
{
    protected override void Steps()
    {
        var chainOrchestrator = new ResponsibilityChainOrchestrator<IResponsibility<string, string>, string, string>()
            .Append(new ResponsibilityFoo())
            .Append(new ResponsibilityBar())
            .Append(new ResponsibilityFooBar());

        var outputBar = chainOrchestrator.Execute("Bar");
        Logger.LogInformation(outputBar);

        var outputFooBar = chainOrchestrator.Execute("FooBar");
        Logger.LogInformation(outputFooBar);
    }
}