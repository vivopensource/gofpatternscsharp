
# State Pattern

- The state pattern is a behavioral design pattern in which an object can alter its behavior when its internal state changes. This pattern is close to the concept of finite-state machines.
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
class BulbStateContext : StateContext<BulbStateContext>
{
    public BulbStateContext(IState<BulbStateContext> defaultState) : base(defaultState) { }
}

// Create States
class OnState : IState<BulbStateContext>
{
    public void Execute(BulbStateContext context) => Console.WriteLine("Turning " + Name);
    public string Name => "On";
}

class OffState : IState<BulbStateContext>
{
    public void Execute(BulbStateContext context) => Console.WriteLine("Turning " + Name);
    public string Name => "Off";
}

// Pattern execution
var on = new OnState();
var off = new OffState();
IStateContext<BulbStateContext> bulbContext = new BulbStateContext(off);

bulbContext.Execute();
bulbContext.SetState(on);
bulbContext.Execute();
bulbContext.SetState(off);
bulbContext.Execute();
```
```
// Output
Turning Off
Turning On
Turning Off
```

#### Full example

[StatePatternBulbExample](./../../GofConsoleApp/Examples/Behavioral/StatePattern/StatePatternBulbExample.cs)


### Type 2: Execute pattern and expect return value

#### Code
    
```csharp
// Create Context
class DriveStateContext : StateContext<DriveStateContext, string>
{
    public DriveStateContext(IState<DriveStateContext, string> defaultState) : base(defaultState) { }
}

// Create States
class EcoState : IState<DriveStateContext, string>
{
    public string Execute(DriveStateContext context) => "Driving mode: " + Name;
    public string Name => "Eco";
}
class SportsState : IState<DriveStateContext, string>
{
    public string Execute(DriveStateContext context) => "Driving mode: " + Name;
    public string Name => "Sports";
}
class SportsPlusState : IState<DriveStateContext, string>
{
    public string Execute(DriveStateContext context) => "Driving mode: " + Name;
    public string Name => "SportsPlus";
}

// Pattern execution
var eco = new EcoState();
var sport = new SportsState();
var sportsPlus = new SportsPlusState();
IStateContext<DriveStateContext, string> drivingContext = new DriveStateContext(eco);

Console.WriteLine(drivingContext.Execute());
Console.WriteLine("Switching driving mode.");
drivingContext.SetState(sport);
Console.WriteLine(drivingContext.Execute());
Console.WriteLine("Switching driving mode.");
drivingContext.SetState(sportsPlus);
Console.WriteLine(drivingContext.Execute());
```
```
// Output
Driving mode: Eco
Switching driving mode.
Driving mode: Sports
Switching driving mode.
Driving mode: SportsPlus
```

#### Full example

[StatePatternDriveExample](./../../GofConsoleApp/Examples/Behavioral/StatePattern/StatePatternDriveExample.cs)


## Benefits
- It localizes state-specific behavior and partitions behavior for different states.
- It makes state transitions explicit.
- State objects can be shared.

## Similarity with other patterns
- The state pattern can be interpreted as a strategy pattern, which is able to switch a strategy through invocations of methods defined in the pattern's interface.