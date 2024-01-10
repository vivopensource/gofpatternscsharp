
# Command Pattern

- The command pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time. This information includes the method name, the object that owns the method and values for the method parameters.
- Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
- The command pattern allows you to create objects that can queue up actions that are performed on a specific object.

## Structure
- It consists of invoker, command, request, and client (client does pattern execution).
- Invoker: An invoker class that will receive the command objects and execute it.
- Command: A client class that will create a command object and pass it to the invoker class for execution. It will also contain the request object.
- Request: A request class that will contain the action to be performed.
- Client: A client class that will use the command objects.

## Examples

### Type 1: Execute pattern without return value

#### Code

```csharp

// Requests
interface IFoodRequest : ICommandRequest
{
    void Serve();
    void Pack();
}

class Pizza : IFoodRequest
{
    private readonly int count;

    public Pizza(int count = 1) => this.count = count;

    public void Serve() => Console.WriteLine($"-> Serving {count} pizza.");

    public void Pack() => Console.WriteLine($"-> Packing {count} pizza.");
}

class Burger : IFoodRequest
{
    private readonly int count;

    public Burger(int count = 1) => this.count = count;

    public void Serve() => Console.WriteLine($"-> Serving {count} burger.");

    public void Pack() => Console.WriteLine($"-> Packing {count} burger.");
}

// Commands
interface IFoodCommand : ICommand<IFoodRequest> { }

class ServeFoodCommand : AbstractCommand<IFoodRequest>, IFoodCommand
{
    public override void Execute() => Request!.Serve();
}

class DeliverFoodCommand : AbstractCommand<IFoodRequest>, IFoodCommand
{
    public override void Execute() => Request!.Pack();
}

// Invoker
class Restaurant : CommandInvoker<IFoodCommand, IFoodRequest>
{
    public void ServePizza(int count = 1)
    {
        var pizzas = new Pizza(count);
        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(pizzas);
        AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(count);
        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(pizzas);
        AddCommand(deliverOrder);
    }

    public void ServeBurger(int count = 1)
    {
        var burgers = new Burger(count);
        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(burgers);
        AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(count);
        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(burgers);
        AddCommand(deliverOrder);
    }

    public int Prepare() => ExecuteCommands();
}

// Client - Pattern execution
var restaurant = new Restaurant();

// 1st Batch
Console.WriteLine($"Processing 1st order batch.");
restaurant.DeliverPizza(2);
restaurant.DeliverBurger(5);
restaurant.ServeBurger(6);
var prepared = restaurant.Prepare();
Console.WriteLine($"Prepared {prepared} orders.");

Console.WriteLine("----------------------");

// 2nd Batch
Console.WriteLine($"Processing 2nd order batch.");
restaurant.ServeBurger(3);
restaurant.DeliverPizza(2);
restaurant.ServePizza(3);
restaurant.DeliverBurger(4);
prepared = restaurant.Prepare();
Console.WriteLine($"Prepared {prepared} orders.");
```
```
// Output
Processing 1st order batch.
-> Packing 2 pizza.
-> Packing 5 burger.
-> Serving 6 burger.
Prepared 3 orders.
----------------------
Processing 2nd order batch.
-> Serving 3 burger.
-> Packing 2 pizza.
-> Serving 3 pizza.
-> Packing 4 burger.
Prepared 4 orders.
```
#### Full example

[CommandPatternRestaurantExample](./../../GofConsoleApp/Examples/Behavioral/CommandPattern/CommandPatternRestaurantExample.cs)


### Type 2: Execute pattern and expect return value

#### Code

```csharp
// Request
class Draw : ICommandRequest {
    Paint() { Write("Painting..."); }
    Erase() { Write("Erasing..."); }
};

// Command
class DrawCommand : ICommandUndo<Draw> {
    private Draw draw;
    public DrawCommand(Draw draw) { this.draw = draw; }
    void Execute() { draw.Paint(); }
    void Undo() { draw.Erase(); }
};

// Invoker
var canvas = new CommandUndoInvoker<DrawCommand, Draw>();

// Pattern execution
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
// Output
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

## Similarity with other patterns

- The command pattern is a variation on the strategy pattern. It involves separating an action from an object that invokes that action. The command pattern allows you to create objects that can queue up actions that are performed on a specific object. The command pattern is useful for creating a system that can handle undoable actions.
- The command pattern is often used in conjunction with the composite pattern. A composite object is an object that is made up of other objects. The composite object treats its children as objects, but it also treats them as commands. This allows you to create a tree structure of commands.
