using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Responsibilities;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput;

internal class ChainOfResponsibilityExample : AbstractExample
{
    protected override void Steps()
    {
        var orchestrator = GetOrchestrator();

        orchestrator.Append(new ResponsibilityFoo());
        orchestrator.Append(new ResponsibilityBar());
        orchestrator.Append(new ResponsibilityFooBar());

        SetBeforeHandling(orchestrator);

        Logger.LogInformation("------------- START Orchestrator -------------");
        Chain = orchestrator.Chain;

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >>> Bar
        // IsResponsible >>>>> Bar (Executes)
        var outputBar = orchestrator.Execute("Bar");
        Logger.LogInformation(outputBar);


        Logger.LogInformation("------------- START Orchestrator -------------");
        Chain = orchestrator.Chain;

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        var outputFooBar = orchestrator.Execute("FooBar");
        Logger.LogInformation(outputFooBar);
    }

    private void SetBeforeHandling(IResponsibilityChainActionBeforeHandling<string> orchestrator)
    {
        // Adding Before Handling Tasks
        orchestrator.ActionBeforeHandling = () =>
        {
            Logger.LogInformation("---- Responsibility Chain ----");
            Logger.LogInformation(GetChainDetail());
        };

        orchestrator.ActionInputBeforeHandling = input =>
        {
            Logger.LogInformation($"Executing before with input '{input}'.");
            MoveToNext();
        };
    }

    private string GetChainDetail()
    {
        return $"Name({Chain!.Name}).";
    }

    private void MoveToNext()
    {
        Chain = Chain?.Next;
    }

    private static IResponsibilityChainOrchestrator<string, string> GetOrchestrator() =>
        new ResponsibilityChainOrchestrator<string, string>();

    private ResponsibilityChain<string, string>? Chain { get; set; }
}