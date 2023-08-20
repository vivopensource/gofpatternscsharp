using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
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
        orchestrator.Append(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways, "FooChain");

        // Bar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "BarChain");

        // FooBar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityFooBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "FooBarChain");

        SetBeforeHandling(orchestrator);
        SetAfterHandling(orchestrator);

        Logger.LogInformation("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsResponsible >>>>> Bar (Executes)
        // !!! Stops
        orchestrator.Execute("Bar");

        Logger.LogInformation("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        // !!! Stops
        orchestrator.Execute("FooBar");
    }

    private void SetBeforeHandling(IResponsibilityChainOrchestrator<string> orchestrator)
    {
        orchestrator.ActionBeforeHandling = () =>
        {
            Logger.LogInformation("---- Start Responsibility - Handling ----");
            Logger.LogInformation(GetChainDetail(orchestrator));
        };

        orchestrator.ActionInputBeforeHandling =
            input => Logger.LogInformation($"Executing before with input '{input}'.");
    }

    private void SetAfterHandling(IResponsibilityChainActionAfterHandling<string> orchestrator)
    {
        orchestrator.ActionInputAfterHandling =
            input => Logger.LogInformation($"Executing before with input '{input}'.");

        orchestrator.ActionAfterHandling = () =>
        {
            Logger.LogInformation("---- End Responsibility - Handling ----");
            Logger.LogInformation("------------");
        };
    }

    private static string GetChainDetail(IResponsibilityChainOrchestrator<string> orchestrator)
    {
        var c = orchestrator.CurrentChain!;
        return $"Name({c.Name}), HandleOption({c.HandleOption}), InvokeNextHandlerOption({c.InvokeNextHandlerOption}).";
    }

    private static IResponsibilityChainOrchestrator<string> GetOrchestrator() =>
        new ResponsibilityChainOrchestrator<string>();
}