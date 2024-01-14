using GofConsoleApp.Examples.Behavioral.CorPattern.InputWithOutputComponents;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;

namespace GofConsoleApp.Examples.Behavioral.CorPattern;

internal class CorPatternExampleWithOutput : BaseExample
{
    protected override bool Execute()
    {
        var orchestrator = new ResponsibilityChainOrchestrator<string, string>();

        orchestrator.Append(new ResponsibilityFoo(), "FooChain");
        orchestrator.Append(new ResponsibilityBar(), "BarChain");
        orchestrator.Append(new ResponsibilityFooBar(), "FooBarChain");

        Logger.Log("------------- START Orchestrator 1 -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >>> Bar
        // IsResponsible >>>>> Bar (Executes)
        var outputBar = orchestrator.Execute("Bar");
        Logger.Log(outputBar);


        Logger.Log("------------- START Orchestrator 2 -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        var outputFooBar = orchestrator.Execute("FooBar");
        Logger.Log(outputFooBar);

        return true;
    }
}