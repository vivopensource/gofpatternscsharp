using Core.Console.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

namespace GofConsoleApp.Examples.Behavioral.CorPattern;

internal class CorPatternExample : BaseExample
{
    protected override bool Execute()
    {
        ImplementationUsingInterface();
        ImplementationUsingConcreteClass();
        return true;
    }

    private void ImplementationUsingInterface()
    {
        var orchestrator =
            new GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple.ResponsibilityChainOrchestrator
                <string>();

        // Responsibility - Foo, Handle - WhenResponsible, Invoke Next >>> WhenNotResponsible
        var fooHandler = new ResponsibilityFoo(Logger);
        orchestrator.Append(fooHandler, "FooResponsibility");

        // Responsibility - Bar, Handle - WhenResponsible, Invoke Next - WhenNotResponsible
        var barHandler = new ResponsibilityBar(Logger);
        orchestrator.Append(barHandler, "BarResponsibility");


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

    private void ImplementationUsingConcreteClass()
    {
        var orchestrator =
            new GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple.ResponsibilityChainOrchestrator
                <string>();

        // Responsibility - Foo, Handle - WhenResponsible, Invoke Next >>> WhenNotResponsible
        var executeFoo = new Action<string>(x => Logger.Log($"Handling '{x}' by 'Foo Handler'"));
        var fooHandler = new Responsibility<string>(i => "Foo".Equals(i), executeFoo);
        orchestrator.Append(fooHandler, "FooResponsibility");

        // Responsibility - Bar, Handle - WhenResponsible, Invoke Next - WhenNotResponsible
        var barExecute = new Action<string>(x => Logger.Log($"Handling '{x}' by 'Bar Handler'"));
        var barHandler = new Responsibility<string>(i => "Bar".Equals(i), barExecute);
        orchestrator.Append(barHandler, "BarResponsibility");


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


    private class ResponsibilityFoo : IResponsibility<string>
    {
        private readonly IConsoleLogger logger;

        public ResponsibilityFoo(IConsoleLogger logger) => this.logger = logger;

        public bool IsResponsible(string input) => "Foo".Equals(input);

        public void Handle(string input) => logger.Log($"Handled '{input}' by 'FooCoR'");
    }

    private class ResponsibilityBar : IResponsibility<string>
    {
        private readonly IConsoleLogger logger;

        public ResponsibilityBar(IConsoleLogger logger) => this.logger = logger;

        public bool IsResponsible(string input) => "Bar".Equals(input);

        public void Handle(string input) => logger.Log($"Handled '{input}' by 'BarCoR'");
    }
}