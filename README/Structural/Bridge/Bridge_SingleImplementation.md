## Bridge pattern with single implementation


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


### 1. With parameter input

```csharp
// Abstraction in bridge pattern
interface IManagement : IBridgeAbstractionImpl<IProcess, Employee> { }

// Refined abstraction - Event management
class EventManagement : BridgeAbstractionImpl<IProcess, Employee>, IManagement
{
    public EventManagement(string purpose) =>
        Console.WriteLine($"Managing event for: {purpose}.");
}

// Refined abstraction - Travel management
class TravelManagement : BridgeAbstractionImpl<IProcess, Employee>, IManagement
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

IManagement annualConference1 = new EventManagement("Annual conference", registerEvent, taskPresentation);
annualConference1.Manage(emp1);

IManagement annualConference2 = new EventManagement("Annual conference", registerEvent);
annualConference2.Manage(emp2);

IProcess taskSalesPitch = new TaskAssignment("Sales pitch");
IManagement salesTravel = new TravelManagement("Sales", taskSalesPitch);
salesTravel.Manage(emp1);

IProcess registerTravel = new Registration();
IProcess taskSystemUpgrade = new TaskAssignment("System upgrade");
IManagement maintenanceTravel = new TravelManagement("Maintenance", registerTravel, taskSystemUpgrade);
maintenanceTravel.Manage(emp2);
```

```
// Output
Managing event for: Annual conference.
 - Registering employee: 1 [Jane Doe].
Managing event for: Annual conference.
 - Registering employee: 2 [John Doe].
Managing travel for: Sales.
 - Assigning employee 1 [Jane Doe] with task [Sales pitch].
Managing travel for: Maintenance.
 - Assigning employee 2 [John Doe] with task [System upgrade].
```

#### Full example

[BridgePatternExampleSingleImplementations](./../../../GofConsoleApp/Examples/Structural/BridgePattern/BridgePatternExampleSingleImplementations.cs)

### 2. Without parameter input, refer test

[BridgeAbstractionImplTests](./../../../GofPatternsTests/Structural/BridgePattern/Implementations/BridgeAbstractionImplTests.cs)

