using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input;

internal class ChainOfResponsibilityExample : AbstractExample
{
    protected override void Steps()
    {
        var orchestrator = GetOrchestrator();

        // Foo - Responsibility
        // Handle >>> Always
        // Invoke Next >>> Always
        orchestrator.Append(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways);

        // Bar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        // FooBar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityFooBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        SetBeforeHandling(orchestrator);
        SetAfterHandling(orchestrator);

        Logger.LogInformation("------------- START Orchestrator -------------");
        Chain = orchestrator.Chain;

        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsResponsible >>>>> Bar (Executes)
        // !!! Stops
        orchestrator.Execute("Bar");

        Logger.LogInformation("------------- START Orchestrator -------------");
        Chain = orchestrator.Chain;

        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        // !!! Stops
        orchestrator.Execute("FooBar");
    }

    private void SetBeforeHandling(IResponsibilityChainActionBeforeHandling<string> orchestrator)
    {
        orchestrator.ActionBeforeHandling = () =>
        {
            Logger.LogInformation("---- Responsibility Chain ----");
            Logger.LogInformation(GetChainDetail());
        };

        orchestrator.ActionInputBeforeHandling =
            input => Logger.LogInformation($"Executing before with input '{input}'.");
    }

    private void SetAfterHandling(IResponsibilityChainActionAfterHandling<string> orchestrator)
    {
        orchestrator.ActionInputAfterHandling =
            input => Logger.LogInformation($"Executing before with input '{input}'.");

        orchestrator.ActionAfterHandling = MoveToNext;
    }

    private string GetChainDetail()
    {
        return
            $"Name({Chain!.Name}), HandleOption({Chain!.HandleOption}), InvokeNextHandlerOption({Chain!.InvokeNextHandlerOption}).";
    }

    private void MoveToNext()
    {
        Chain = Chain?.Next;
    }

    private ResponsibilityChain<string>? Chain { get; set; }

    private static IResponsibilityChainOrchestrator<string> GetOrchestrator() =>
        new ResponsibilityChainOrchestrator<string>();
}