
# Adapter Pattern

- The adapter pattern is a structural design pattern that allows objects with incompatible interfaces to collaborate.
- The adapter acts as a wrapper between two objects. It catches calls for one object and transforms them to format and interface recognizable by the second object.

## Structure

- It consists of target, adapter and adaptee.
- Target: An interface that will contain the method to be implemented by the concrete component and decorator.
- Adapter: A class that will contain the reference to the component and will implement the same interface implemented by the component so that it can be used by the client.
- Adaptee: A class that will contain the actual implementation of the method.


## Examples


```csharp
// Adaptee interface
interface IEmployee
{
    string Id { get; }
    string FirstName { get; }
    string LastName { get; }
    string Address { get; }
}

// Adaptee implementation
class Employee : IEmployee
{
    public Employee(string id, string firstName, string lastName, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
}

// Target
interface ITraveller
{
    string FullName { get; }
    string Address { get; }
}

// Adapter
class EmployeeTravellerAdapter : IAdapter<IEmployee, ITraveller>, ITraveller
{
    public EmployeeTravellerAdapter(IEmployee adaptee)
    {
        FullName = $"{adaptee.FirstName} {adaptee.LastName}";
        Address = adaptee.Address;
    }

    public string FullName { get; }
    public string Address { get; }
}

// Pattern execution
IEmployee employee = new Employee("1", "John", "Doe", "Success Lane 1");
Console.WriteLine($"Employee: {employee.Id}, {employee.FirstName}, {employee.LastName}, {employee.Address}");

ITraveller sutAdapter = new EmployeeTravellerAdapter(employee);
Console.WriteLine($"Traveller '{sutAdapter.FullName}' is travelling to: {sutAdapter.Address}");
```

```
// Output
Employee: 1, John, Doe, Success Lane 1
Traveller 'John Doe' is travelling to: Success Lane 1
```
#### Full example

[AdapterPatternExample](./../../GofConsoleApp/Examples/Structural/AdapterPattern/AdapterPatternExample.cs)


## Benefits

- Allows two incompatible interfaces to work together.
- Allows reusability of existing functionality.
- Allows legacy code to work with modern code.

## Similarity with other patterns

- Adapter provides a different interface to the wrapped object, Proxy provides it with the same interface, and Decorator provides it with an enhanced interface.
- Adapter and Facade are similar: both wrap existing interfaces, and both can expose a different interface than the wrapped objects. However, the intents of these patterns are different. An Adapter focuses on providing a different interface to the wrapped object, while a Facade’s intent is to provide a simplified interface to a subsystem or class.
- Adapter changes the interface of an existing object, while Decorator enhances an object without changing its interface. In addition, Decorator supports recursive composition, which isn’t possible when you use Adapter.