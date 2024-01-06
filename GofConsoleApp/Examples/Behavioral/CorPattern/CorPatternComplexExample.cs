using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorInvokeNextOptions;
using ResponsibilityBar = GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents.ResponsibilityBar;
using ResponsibilityFoo = GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents.ResponsibilityFoo;
using ResponsibilityFooBar = GofConsoleApp.Examples.Behavioral.CorPattern.InputExampleComponents.ResponsibilityFooBar;

namespace GofConsoleApp.Examples.Behavioral.CorPattern;

internal class CorPatternComplexExample : AbstractExample
{
    protected override bool Execute()
    {
        Example1();
        Example2();
        return true;
    }

    private void Example1()
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
        // - Start with >>> Foo
        // - Input >> Foo
        // ### HandleWhenResponsible >>>> Foo (Executes)
        orchestrator.Execute("Foo");

        Logger.Log("------------- START Orchestrator with input Bar -------------");
        // - Start with >>> Foo
        // - Input >> Bar
        // ### HandleWhenResponsible >>>> Foo (Not Executes) 
        // *** Invokes >> Bar (InvokeNextWhenNotResponsible)
        // ### HandleWhenResponsible >>>>> Bar (Executes)
        orchestrator.Execute("Bar");
    }

    private void Example2()
    {
        var orchestrator1 = new ResponsibilityChainOrchestrator<string> { Name = "Orchestrator 1" };
        orchestrator1.Append(new ResponsibilityFoo(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);
        orchestrator1.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        Logger.Log($"------------- START {orchestrator1.Name} -------------");
        // - Start with >>> Foo
        // - Input >> Foo
        // ### HandleWhenResponsible >>>> Foo (Not Executes)
        // *** Invokes >> Bar (InvokeNextWhenNotResponsible)
        // ### HandleWhenResponsible >>>>> Bar (Executes)
        orchestrator1.Execute("Bar");

        var orchestrator2 = new ResponsibilityChainOrchestrator<string> { Name = "Orchestrator 2" };
        orchestrator2.Append(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways);
        orchestrator2.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);
        orchestrator2.Append(new ResponsibilityFooBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        Logger.Log($"------------- START {orchestrator2.Name} -------------");
        // - Start with >>> Foo
        // - Input >> FooBar
        // ### HandleAlways >>>> Foo (Executes) 
        // *** Invokes >> Bar (InvokeNextAlways)
        // ### HandleWhenResponsible >>>>> Bar (Not Executes)
        // *** Invokes >> FooBar (InvokeNextWhenNotResponsible)
        // ### HandleWhenResponsible >>>>> FooBar (Executes)
        orchestrator2.Execute("FooBar");
    }
}