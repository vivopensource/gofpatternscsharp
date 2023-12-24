
# State Pattern

- The state pattern is a behavioral design pattern in which an object can alter its behavior when its internal state changes. This pattern is close to the concept of finite-state machines.
- Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
- The state pattern is used in computer programming to encapsulate varying behavior for the same object based on its internal state. This can be a cleaner way for an object to change its behavior at runtime without resorting to conditional statements and thus improve maintainability.

## Structure
- It consists of context and state.
- Context: A context class that will contain the state object.
- State: A state class that will contain the action to be performed.

## Examples

### Type 1: Execute pattern without return value

#### Code

```csharp
// Create Context
class ExampleStateContext : StateContext<ExampleStateContext>
{
    public ExampleStateContext(IState<ExampleStateContext> defaultState) : base(defaultState) { }
}

// Create States
class OnState : IState<ExampleStateContext>
{
    public void Execute(ExampleStateContext context) => Console.WriteLine("Turning " + Name);
    public string Name => nameof(OnState);
}
class OffState : IState<ExampleStateContext>
{
    public void Execute(ExampleStateContext context) => Console.WriteLine("Turning " + Name);
    public string Name => nameof(OffState);
}

// Execute States
var on = new OnState();
var off = new OffState();
IStateContext<ExampleStateContext> bulbContext = new ExampleStateContext(off);
bulbContext.Execute();
bulbContext.SetState(on);
bulbContext.Execute();
bulbContext.SetState(off);
bulbContext.Execute();
```
```
// Output
Turning OffState
Turning OnState
Turning OffState
```

#### Full example

[StatePatternBulbExample](./../../GofConsoleApp/Examples/Behavioral/StatePattern/StatePatternBulbExample.cs)


### Type 2: Execute pattern and expect return value

#### Code
    
```csharp
// Create Context
```


## Benefits
- It localizes state-specific behavior and partitions behavior for different states.
- It makes state transitions explicit.
- State objects can be shared.

## Connection with other patterns
- The state pattern can be interpreted as a strategy pattern, which is able to switch a strategy through invocations of methods defined in the pattern's interface.