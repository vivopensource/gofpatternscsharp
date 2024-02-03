# Bridge Pattern

- The Bridge Pattern is a structural design pattern that decouples an abstraction from its implementation so that the two can vary independently.
- It is used when a class has multiple implementations and the client needs to choose one of them at runtime.

## Structure

- It consists of abstraction, refined abstraction, implementor and concrete implementor.
- Abstraction: It is an interface that contains the method to be implemented by the refined abstraction.
- Refined Abstraction: It is a class that will implement the abstraction and will contain the reference to the implementor.
- Implementor: It is an interface that contains the actual implementation of the method.
- Concrete Implementor: It is a class that will contain the actual implementation of the method.

## Examples

### Components

```csharp
// Data
class Employee
{
    public Employee(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
}
```

### 1. Implement pattern in most basic way

```csharp
// Abstraction in bridge pattern
interface IManagement
    : IBridgeAbstraction<IProcessEmployee> // Used as placeholder only
{
    void Manage(Employee emp);
}

// Refined abstraction - Event management
class EventManagement : IManagement
{
    private readonly IProcessEmployee impl;

    public EventManagement(string name, IProcessEmployee impl)
    {
        this.impl = impl;
        Console.WriteLine($"Managing event for: {name}.");
    }

    public void Manage(Employee emp)
    {
        impl.Process(emp);
    }
}

// Refined abstraction - Travel management
class TravelManagement : IManagement
{
    private readonly IProcessEmployee impl;

    public TravelManagement(string name, IProcessEmployee impl)
    {
        this.impl = impl;
        Console.WriteLine($"Managing travel for: {name}.");
    }

    public void Manage(Employee emp)
    {
        impl.Process(emp);
    }
}

// Implementor for bridge pattern
interface IProcessEmployee
    : IBridgeImplementation  // Used as placeholder only
{
    void Process(Employee emp);
}

// Concrete implementor - Register
class Register : IProcessEmployee
{
    public void Process(Employee emp) =>
        Console.WriteLine($"Registering employee: {emp.Id} [{emp.FirstName} {emp.LastName}].");
}

// Concrete implementor - Task assignment
class TaskAssignment : IProcessEmployee
{
    private readonly string name;

    public TaskAssignment(string name) => this.name = name;

    public void Process(Employee emp) =>
        Console.WriteLine($"Assigning employee {emp.Id} [{emp.FirstName} {emp.LastName}] with task [{name}].");
}

// Pattern execution
var emp1 = new Employee("1", "Jane", "Doe");
var emp2 = new Employee("2", "John", "Doe");

IProcessEmployee register = new Register();
IManagement yearlyEvent = new EventManagement("Yearly Event", register);
yearlyEvent.Manage(emp1);
yearlyEvent.Manage(emp2);

IProcessEmployee taskSalesPitch = new TaskAssignment("Sales pitch");
IManagement salesTravel = new TravelManagement("Sales", taskSalesPitch);
salesTravel.Manage(emp1);

IProcessEmployee taskSystemUpgrade = new TaskAssignment("System upgrade");
IManagement maintenanceTravel = new TravelManagement("Maintenance", taskSystemUpgrade);
maintenanceTravel.Manage(emp2);
```

```
// Output
Managing event for: Yearly Event.
Registering employee: 1 [Jane Doe].
Registering employee: 2 [John Doe].
Managing travel for: Sales.
Assigning employee 1 [Jane Doe] with task [Sales pitch].
Managing travel for: Maintenance.
Assigning employee 2 [John Doe] with task [System upgrade].
```

### Classes and interfaces used in example:

- [IBridgeAbstraction](./../../GofPatterns/Structural/BridgePattern/IBridgeAbstraction.cs)
- [IBridgeImplementation](./../../GofPatterns/Structural/BridgePattern/IBridgeImplementation.cs)

## Benefits

- It allows the client to choose the implementation at runtime.
- It separates the abstraction from its implementation.
- It provides a cleaner and more maintainable code.
- It allows the client to use the abstraction and implementation independently.

## Drawbacks

- It can make the code more complex.

## When to use

- When a class has multiple implementations and the client needs to choose one of them at runtime.
- When the implementation of an abstraction should be decoupled from the abstraction itself.

## Similarity with other patterns

- It is similar to the Adapter Pattern, but the Bridge Pattern is used when the client needs to choose one of the multiple implementations at runtime.
- It is similar to the Strategy Pattern, but the Bridge Pattern is used when the client needs to choose one of the multiple implementations at runtime.
- It is similar to the Abstract Factory Pattern, but the Bridge Pattern is used when the client needs to choose one of the multiple implementations at runtime.