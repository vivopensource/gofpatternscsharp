using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

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
        var orchestrator = new ResponsibilityChainOrchestrator<string>();

        // Responsibility - Foo, Handle - WhenResponsible, Invoke Next >>> WhenNotResponsible
        var executeFoo = new Action<string>(x => Logger.Log($"Handling '{x}' by 'Foo Handler'"));
        var fooHandler = new Responsibility<string>(i => "Foo".Equals(i), executeFoo);
        orchestrator.Append(fooHandler, HandleWhenResponsible, InvokeNextWhenNotResponsible, "FooResponsibility");

        // Responsibility - Bar, Handle - WhenResponsible, Invoke Next - WhenNotResponsible
        var barExecute = new Action<string>(x => Logger.Log($"Handling '{x}' by 'Bar Handler'"));
        var barHandler = new Responsibility<string>(i => "Bar".Equals(i), barExecute);
        orchestrator.Append(barHandler, HandleWhenResponsible, InvokeNextWhenNotResponsible, "BarResponsibility");


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
        var orchestrator = new ResponsibilityChainOrchestrator<string>();

        // Responsibility - Foo, Handle - Always, Invoke Next - Always
        orchestrator.Append(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways, "FooChain");

        // Responsibility - Bar, Handle - WhenResponsible, Invoke Next - WhenNotResponsible
        orchestrator.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "BarChain");

        // Responsibility - FooBar, Handle - WhenResponsible, Invoke Next - WhenNotResponsible
        orchestrator.Append(new ResponsibilityFooBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible,
            "FooBarChain");

        // SET Before-Handling
        orchestrator.ExecuteBeforeWithInput = input => Logger.Log($"Executing before with input '{input}'.");
        orchestrator.ExecuteBefore = () =>
        {
            Logger.Log("---- Start Responsibility - Handling ----");
            Logger.Log(GetChainDetail(orchestrator));
        };

        // SET After-Handling
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
}