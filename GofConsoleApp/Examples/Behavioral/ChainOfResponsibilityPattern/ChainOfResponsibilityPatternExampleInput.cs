using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;

internal class ChainOfResponsibilityPatternExampleInput : AbstractExample
{
    protected override bool Execute()
    {
        ExecuteSimpleExample();
        ExecuteComplexExample();
        return true;
    }

    private void ExecuteSimpleExample()
    {
        var orchestrator = GetOrchestrator();

        // Foo - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityFoo(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "FooChain");

        // Bar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        orchestrator.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "BarChain");


        Logger.Log("------------- START Orchestrator -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // !!! Stops
        orchestrator.Execute("Foo");

        Logger.Log("------------- START Orchestrator -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Not Executes) 
        // Invokes >> Bar
        // IsResponsible >>>>> Bar (Executes)
        // !!! Stops
        orchestrator.Execute("Bar");
    }

    private void ExecuteComplexExample()
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

        // Set Before-Handling
        orchestrator.ExecuteBeforeWithInput = input => Logger.Log($"Executing before with input '{input}'.");
        orchestrator.ExecuteBefore = () =>
        {
            Logger.Log("---- Start Responsibility - Handling ----");
            Logger.Log(GetChainDetail(orchestrator));
        };

        // Set After-Handling
        orchestrator.ExecuteAfterWithInput = input => Logger.Log($"Executing before with input '{input}'.");
        orchestrator.ExecuteAfter = () =>
        {
            Logger.Log("---- End Responsibility - Handling ----");
            Logger.Log("------------");
        };

        Logger.Log("------------- START Orchestrator -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsResponsible >>>>> Bar (Executes)
        // !!! Stops
        orchestrator.Execute("Bar");

        Logger.Log("------------- START Orchestrator -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        // !!! Stops
        orchestrator.Execute("FooBar");
    }

    private static string GetChainDetail(IResponsibilityChainOrchestrator<string> orchestrator)
    {
        var c = orchestrator.CurrentChain!;
        return $"Name({c.Name}), HandleOption({c.HandleOption}), InvokeNextHandlerOption({c.InvokeNextHandlerOption}).";
    }

    private static IResponsibilityChainOrchestrator<string> GetOrchestrator() =>
        new ResponsibilityChainOrchestrator<string>();
}