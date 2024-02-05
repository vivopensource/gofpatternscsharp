## Using Bridge pattern with Marker interface

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

### Example using Marker interface

```csharp
// Abstraction in bridge pattern
interface IManagement 
    : IBridgeAbstraction<IProcess> // (Marker)
{
    void Manage(Employee emp);
}

// Refined abstraction - Event management
class EventManagement : IManagement
{
    private readonly List<IProcess> impls;

    public EventManagement(string purpose, params IProcess[] impls)
    {
        this.impls = new List<IProcess>(impls);
        Console.WriteLine($"Managing event for: {purpose}.");
    }

    public void Manage(Employee emp) => impls.ForEach(impl => impl.Process(emp));
}

// Refined abstraction - Travel management
class TravelManagement : IManagement
{
    private readonly List<IProcess> impls;

    public TravelManagement(string purpose, params IProcess[] impls)
    {
        this.impls = new List<IProcess>(impls);
        Console.WriteLine($"Managing travel for: {purpose}.");
    }

    public void Manage(Employee emp) => impls.ForEach(impl => impl.Process(emp));
}

// Implementor for bridge pattern
interface IProcess 
    : IBridgeImplementation // (Marker)
{
    void Process(Employee emp);
}

// Concrete implementor - Register
class Registration : IProcess
{
    public void Process(Employee emp) =>
        Console.WriteLine($" - Registering employee: {emp.Id} [{emp.FirstName} {emp.LastName}].");
}

// Concrete implementor - Task assignment
class TaskAssignment : IProcess
{
    private readonly string name;

    public TaskAssignment(string name) => this.name = name;

    public void Process(Employee emp) =>
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

[BridgePatternExampleWithMarker](./../../../GofConsoleApp/Examples/Structural/BridgePattern/BridgePatternExampleWithMarker.cs)