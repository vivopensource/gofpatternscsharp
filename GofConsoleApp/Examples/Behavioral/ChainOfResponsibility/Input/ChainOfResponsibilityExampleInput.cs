using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Orchestrators;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Responsibilities;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input;

internal class ChainOfResponsibilityExampleInput : AbstractExample
{
    protected override void Steps()
    {
        var chainOrchestrator = new ResponsibilityChainOrchestratorInput(Logger);

        // Foo - Responsibility
        // Handle >>> Always
        // Invoke Next >>> Always
        chainOrchestrator.Append(new ResponsibilityFoo(Logger), HandleAlways, InvokeNextAlways);

        // Bar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        chainOrchestrator.Append(new ResponsibilityBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        // FooBar - Responsibility
        // Handle >>> WhenResponsible
        // Invoke Next >>> WhenNotResponsible
        chainOrchestrator.Append(new ResponsibilityFooBar(Logger), HandleWhenResponsible, InvokeNextWhenNotResponsible);

        // Start with >>> Foo
        // Executes >>> Foo
        // Invokes >>> Bar
        chainOrchestrator.Execute("Bar");

        // Start with >>> Foo
        // Executes >>> Foo
        // Invokes >>> Bar
        // Invokes >>> FooBar
        // Executes >>> FooBar
        chainOrchestrator.Execute("FooBar");
    }
}