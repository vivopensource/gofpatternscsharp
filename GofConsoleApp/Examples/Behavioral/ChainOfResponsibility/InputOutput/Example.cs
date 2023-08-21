using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Responsibilities;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput;

internal class Example : AbstractExample
{
    protected override void Steps()
    {
        var orchestrator = GetOrchestrator();

        orchestrator.Append(new ResponsibilityFoo(), "FooChain");
        orchestrator.Append(new ResponsibilityBar(), "BarChain");
        orchestrator.Append(new ResponsibilityFooBar(), "FooBarChain");

        SetBeforeHandling(orchestrator);

        Logger.LogInformation("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >>> Bar
        // IsResponsible >>>>> Bar (Executes)
        var outputBar = orchestrator.Execute("Bar");
        Logger.LogInformation(outputBar);


        Logger.LogInformation("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        var outputFooBar = orchestrator.Execute("FooBar");
        Logger.LogInformation(outputFooBar);
    }

    private void SetBeforeHandling(IResponsibilityChainOrchestrator<string, string> orchestrator)
    {
        // Adding Before Handling Tasks
        orchestrator.ExecuteBefore = () =>
        {
            Logger.LogInformation("---- Responsibility Chain ----");
            Logger.LogInformation($"Name({orchestrator.CurrentChain!.Name}).");
        };

        orchestrator.ExecuteBeforeWithInput = input =>
        {
            Logger.LogInformation($"Executing before with input '{input}'.");
        };
    }

    private static IResponsibilityChainOrchestrator<string, string> GetOrchestrator() =>
        new ResponsibilityChainOrchestrator<string, string>();
}