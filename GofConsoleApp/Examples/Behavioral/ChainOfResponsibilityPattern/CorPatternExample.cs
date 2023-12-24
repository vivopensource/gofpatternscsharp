using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;

internal class CorPatternExample : AbstractExample
{
    protected override bool Execute()
    {
        ExecuteSimpleExample();

        ExecuteComplexExample(GetOrchestrator("Orchestrator 1", GetOptions1()), "Bar");
        ExecuteComplexExample(GetOrchestrator("Orchestrator 2", GetOptions2()), "FooBar");

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


        Logger.Log("------------- START Orchestrator with input Foo -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Executes) 
        // !!! Stops
        orchestrator.Execute("Foo");

        Logger.Log("------------- START Orchestrator with input Bar -------------");
        // Start with >>> Foo
        // HandleAlways >>>> Foo (Not Executes) 
        // Invokes >> Bar
        // IsResponsible >>>>> Bar (Executes)
        // !!! Stops
        orchestrator.Execute("Bar");
    }


    private void ExecuteComplexExample(IResponsibilityChainOrchestrator<string> orchestrator, string inputCoR)
    {
        // SET Before-Handling
        orchestrator.ExecuteBeforeWithInput = input => Logger.Log($"Executing before with input '{input}'.");
        orchestrator.ExecuteBefore = () =>
        {
            Logger.Log("---- Start Responsibility - Handling ----");
            Logger.Log(GetChainDetail(orchestrator));
        };

        // SET After-Handling
        orchestrator.ExecuteAfterWithInput = input => Logger.Log($"Executing after with input '{input}'.");
        orchestrator.ExecuteAfter = () =>
        {
            Logger.Log("---- End Responsibility - Handling ----");
            Logger.Log("------------");
        };

        Logger.Log($"------------- START {orchestrator.Name} -------------");
        orchestrator.Execute(inputCoR);
    }

    private ChainOrchestratorOption[] GetOptions1() =>
        new[]
        {
            // (Responsibility - Foo) , (Handle - WhenResponsible) , (Invoke Next - WhenNotResponsible)
            new ChainOrchestratorOption(new ResponsibilityFoo(Logger), HandleWhenResponsible,
                InvokeNextWhenNotResponsible),
            // (Responsibility - Bar) , (Handle - WhenResponsible) , (Invoke Next - WhenNotResponsible)
            new ChainOrchestratorOption(new ResponsibilityBar(Logger), HandleWhenResponsible,
                InvokeNextWhenNotResponsible)
        };

    private ChainOrchestratorOption[] GetOptions2() =>
        new[]
        {
            // (Responsibility - Foo) , (Handle - Always) , (Invoke Next - Always)
            new ChainOrchestratorOption(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways),
            // (Responsibility - Bar) , (Handle - WhenResponsible) , (Invoke Next - WhenNotResponsible)
            new ChainOrchestratorOption(new ResponsibilityBar(Logger), HandleWhenResponsible,
                InvokeNextWhenNotResponsible),
            // (Responsibility - FooBar) , (Handle - WhenResponsible) , (Invoke Next - WhenNotResponsible)
            new ChainOrchestratorOption(new ResponsibilityFooBar(Logger), HandleWhenResponsible,
                InvokeNextWhenNotResponsible)
        };

    private IResponsibilityChainOrchestrator<string> GetOrchestrator(string name, ChainOrchestratorOption[] options)
    {
        var orchestrator = new ResponsibilityChainOrchestrator<string>() { Name = name };

        options.ToList().ForEach(x =>
        {
            orchestrator.Append(x.Responsibility, x.HandleOption, x.InvokeNextHandlerOption, x.Responsibility.Name);
        });

        return orchestrator;
    }

    private class ChainOrchestratorOption
    {
        public ChainOrchestratorOption(AbstractResponsibility responsibility,
            ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption)
        {
            Responsibility = responsibility;
            HandleOption = handleOption;
            InvokeNextHandlerOption = invokeNextHandlerOption;
        }

        public AbstractResponsibility Responsibility { get; }
        public ChainOrchestratorHandleOptions HandleOption { get; init; }
        public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; init; }
    }

    private static string GetChainDetail(IResponsibilityChainOrchestrator<string> orchestrator)
    {
        var c = orchestrator.CurrentChain!;
        return $"Name({c.Name}), HandleOption({c.HandleOption}), InvokeNextHandlerOption({c.InvokeNextHandlerOption}).";
    }
}