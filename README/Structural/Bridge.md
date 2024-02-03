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

### Data

```csharp
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

### 2. Using multiple implementations

```csharp
// Abstraction in bridge pattern
interface IManagement : IBridgeAbstractionsImpl<IProcess, Employee> { }

// Refined abstraction - Event management
class EventManagement : BridgeAbstractionsImpl<IProcess, Employee>, IManagement
{
    public EventManagement(string purpose) =>
        Console.WriteLine($"Managing event for: {purpose}.");
}

// Refined abstraction - Travel management
class TravelManagement : BridgeAbstractionsImpl<IProcess, Employee>, IManagement
{
    public TravelManagement(string purpose) =>
        Console.WriteLine($"Managing travel for: {purpose}.");
}

// Implementor for bridge pattern
interface IProcess : IBridgeImplementationImpl<Employee> { }

// Concrete implementor - Register
class Registration : IProcess
{
    public void Execute(Employee emp) =>
        Console.WriteLine($" - Registering employee: {emp.Id} [{emp.FirstName} {emp.LastName}].");
}

// Concrete implementor - Task assignment
class TaskAssignment : IProcess
{
    private readonly string name;

    public TaskAssignment(string name) => this.name = name;

    public void Execute(Employee emp) =>
        Console.WriteLine($" - Assigning employee {emp.Id} [{emp.FirstName} {emp.LastName}] with task [{name}].");
}

// Pattern execution
var emp1 = new Employee("1", "Jane", "Doe");
var emp2 = new Employee("2", "John", "Doe");

IProcess registerEvent = new Registration();
IProcess taskPresentation = new TaskAssignment("Goals presentation");

IManagement annualConference1 = new EventManagement("Annual conference");
annualConference1.Add(registerEvent, taskPresentation);
annualConference1.Execute(emp1);

IManagement annualConference2 = new EventManagement("Annual conference");
annualConference2.Add(registerEvent);
annualConference2.Execute(emp2);

IProcess taskSalesPitch = new TaskAssignment("Sales pitch");
IManagement salesTravel = new TravelManagement("Sales");
salesTravel.Add(taskSalesPitch);
salesTravel.Execute(emp1);

IProcess registerTravel = new Registration();
IProcess taskSystemUpgrade = new TaskAssignment("System upgrade");
IManagement maintenanceTravel = new TravelManagement("Maintenance");
maintenanceTravel.Add(registerTravel, taskSystemUpgrade);
maintenanceTravel.Execute(emp2);
```

```
// Output
Managing event for: Annual conference.
 - Registering employee: 1 [Jane Doe].
 - Assigning employee 1 [Jane Doe] with task [Goals presentation].
Managing event for: Annual conference.
 - Registering employee: 2 [John Doe].
Managing travel for: Sales.
 - Assigning employee 1 [Jane Doe] with task [Sales pitch].
Managing travel for: Maintenance.
 - Registering employee: 2 [John Doe].
 - Assigning employee 2 [John Doe] with task [System upgrade].
```

#### Full example

[BridgePatternExample](./../../GofConsoleApp/Examples/Structural/BridgePattern/BridgePatternExample.cs)


### 3. Using marker interfaces

[Bridge Pattern with Marker](Bridge/Bridge_Marker.md)


### Classes and interfaces used in examples:

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