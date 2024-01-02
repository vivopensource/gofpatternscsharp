
# Command Pattern

- The command pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time. This information includes the method name, the object that owns the method and values for the method parameters.
- Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
- The command pattern allows you to create objects that can queue up actions that are performed on a specific object.

## Structure
- It consists of invoker, command and request.
- Invoker: An invoker class that will receive the command objects and execute it.
- Command: A client class that will create a command object and pass it to the invoker class for execution. It will also contain the request object.
- Request: A request class that will contain the action to be performed.

## Examples

### Type 1: Execute pattern without return value

#### Code

```csharp
ICommandInvoker<in TCommand, TCommandRequest> invoker = new CommandInvoker<TCommand, TCommandRequest>();
invoker.SetCommand(ICommand<TCommandRequest> command1);
invoker.SetCommand(ICommand<TCommandRequest> command2);
commandInvoker.ExecuteCommands();
```
#### Full example

[CommandPatternRestaurantExample](./../../GofConsoleApp/Examples/Behavioral/CommandPattern/CommandPatternRestaurantExample.cs)


### Type 2: Execute pattern and expect return value

#### Code

```csharp
class Draw : ICommandRequest {
    Paint() { Write("Painting..."); }
    Erase() { Write("Erasing..."); }
};

class DrawCommand : ICommandUndo<Draw> {
    private Draw draw;
    public DrawCommand(Draw draw) { this.draw = draw; }
    void Execute() { draw.Paint(); }
    void Undo() { draw.Erase(); }
};

var canvas = new CommandUndoInvoker<DrawCommand, Draw>();

var draw = new Draw();

var drawCommand = new DrawCommand();
drawCommand.AddRequest(draw);
canvas.SetCommand(drawCommand, undoFlag:false);

var eraseCommand = new DrawCommand();
eraseCommand.AddRequest(draw);
canvas.SetCommand(eraseCommand, undoFlag:true);

canvas.ExecuteCommands();
```

```Log
Painting...
Erasing...
```

#### Full example

[CommandPatternUndoOnlineShopExample](./../../GofConsoleApp/Examples/Behavioral/CommandPattern/CommandPatternUndoOnlineShopExample.cs)


## Benefits

- Promote "invocation of a method on an object" to full object status, decouple the execution from the implementation, and support logging changes so that they can be reapplied in case of a system crash. 
- An object that represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.
- Allows you to store lists of code that is executed at a later time or many times.
- A way of structuring a system around a high-level idea of "get this done" where a command object does the work of making sure the right things happen at the right times.
- The command pattern is useful for creating a system that can handle undoable actions.

## Connection with other patterns

- The command pattern is a variation on the strategy pattern. It involves separating an action from an object that invokes that action. The command pattern allows you to create objects that can queue up actions that are performed on a specific object. The command pattern is useful for creating a system that can handle undoable actions.
- The command pattern is often used in conjunction with the composite pattern. A composite object is an object that is made up of other objects. The composite object treats its children as objects, but it also treats them as commands. This allows you to create a tree structure of commands.
