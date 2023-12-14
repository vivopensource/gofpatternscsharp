
# Chain of Responsibility Pattern

- Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
- The CoR pattern can be implemented recursively, with each object's successor holding a reference to its predecessor, or as a loop that keeps track of the successor object in each iteration (see also iterator pattern).
- Launch-and-leave requests with a single processing pipeline that contains many possible handlers.

## Structure
- It consists of handler and orchestrator.
- Handler: A handler class that checks if handle is responsible to handle responsibility and then and execute it.
- Orchestrator: The orchestrator class that configures the responsibility chain and call handlers iteratively.

## Examples

### Input

#### Code

```csharp
// TIn is Input
// ChainOrchestratorHandleOptions >> HandleAlways, HandleWhenResponsible
// ChainOrchestratorInvokeNextOptions >> InvokeNextAlways, InvokeNextWhenResponsible, InvokeNextWhenNotResponsible, InvokeNextNever
IResponsibilityChainOrchestrator<TIn> orchestrator = new ResponsibilityChainOrchestrator<TIn>();
orchestrator.Append(IResponsibility<TIn>, ChainOrchestratorHandleOptions, ChainOrchestratorInvokeNextOptions, "Name>R1");
orchestrator.Append(IResponsibility<TIn>, ChainOrchestratorHandleOptions, ChainOrchestratorInvokeNextOptions, "Name>R2");
orchestrator.Execute(input);
```

#### Full example

[ChainOfResponsibilityPatternExampleInput](./../../GofConsoleApp/Examples/Behavioral/ChainOfResponsibilityPattern/ChainOfResponsibilityPatternExampleInput.cs)

### Input and Output

#### Code

```csharp
// TIn is Input
// TOut is Output
IResponsibilityChainOrchestrator<TIn,TOut> orchestrator = new ResponsibilityChainOrchestrator<TIn,TOut>();
orchestrator.Append(IResponsibility<TIn,TOut>, "Name>R1");
orchestrator.Append(IResponsibility<TIn,TOut>, "Name>R2");
TOut output = orchestrator.Execute(input);
```

#### Full example
[ChainOfResponsibilityPatternExampleInputWithOutput](./../../GofConsoleApp/Examples/Behavioral/ChainOfResponsibilityPattern/ChainOfResponsibilityPatternExampleInputWithOutput.cs)

## Benefits
- An object-oriented linked list with recursive traversal.
- A message dispatcher with optional message caching.
- The CoR pattern is more flexible than static inheritance. It is more applicable when the exact processing sequence is not known beforehand or when the sequence is subject to change.
- The CoR pattern can be implemented as a chain of references or as a centralized dispatcher (see also command pattern) that keeps track of the handlers in some other way.
- The CoR pattern can be implemented with either coroutines or continuations, in which case the chain of responsibility is a coroutine chain in former case or continuation chain in latter case.
- The CoR pattern can be implemented as a chain of responsibility of either objects or static methods. The former is more in keeping with the object-oriented principle of encapsulation. The latter is more in keeping with the functional programming principle of statelessness.
- The CoR pattern can be implemented as a chain of either synchronous or asynchronous handlers. The former is more in keeping with the functional programming principle of referential transparency and iterator pattern. The latter is more in keeping with the actor model principle of asynchronous messaging, location transparency, stateful actors and fault tolerance.

## Connection with other patterns
- The CoR pattern is structurally nearly identical to the decorator pattern, the difference being that for the decorator, all classes handle the request, while for the CoR.
- The CoR pattern is often applied in conjunction with the composite pattern: an object's parent's CoR determines how the parent forwards requests to its children and whether the parent itself handles default requests (see also the mediator pattern).
