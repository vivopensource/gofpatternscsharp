# Composite pattern

- The composite pattern is a structural pattern that allows composing objects into tree structures to represent part-whole hierarchies. It lets clients treat individual objects and compositions of objects uniformly.
- The pattern is used to create a tree structure of objects, where individual objects are treated as a single object, and compositions of objects are treated as a single object.

## Structure

- It consists of component, leaf, and composite.
- Component: The base class or interface that provides the common methods and properties for the leaf and composite.
- Leaf: A class that represents the individual objects in the tree structure.
- Composite: A class that represents the compositions of objects in the tree structure.

## Examples

### Type 1: With input

```csharp
interface IResource : IComponent { }

class Employee : ILeaf, IResource
{
    private readonly string name;
    public Employee(string name) => this.name = name;
    public void Process() => Console.WriteLine($" - Employee working: {name}.");
}

class Team : Composite, IResource
{
    private readonly string name;

    public Team(string name) => this.name = name;

    public override void Process()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Team: {name}.");
        base.Process();
    }
}

// Pattern execution

IResource employeeJack = new Employee("Jack");
IResource employeeJill = new Employee("Jill");
var installers = new Team("Product Installation");
installers.Add(employeeJack, employeeJill);

IResource employeeJohn = new Employee("John");
IResource employeeJane = new Employee("Jane");
var specialists = new Team("Product Specialist");
specialists.Add(employeeJohn, employeeJane);

var support = new Team("Product Support");
support.Add(specialists, installers);
support.Process();
```

```txt
// Output
----------------------------------------
Team: Product Support.
----------------------------------------
Team: Product Specialist.
 - Employee working: John.
 - Employee working: Jane.
----------------------------------------
Team: Product Installation.
 - Employee working: Jack.
 - Employee working: Jill.
```

#### Full example

[CompositePatternExampleWithInput](./../../GofConsoleApp/Examples/Structural/CompositePattern/CompositePatternExampleWithInput.cs)


### Type 2: Without input

```csharp
interface IDeliveryItem : IComponent<string> { }

class DeliveryProduct : ILeaf<string>, IDeliveryItem
{
    private readonly string name;

    public DeliveryProduct(string name)
    {
        this.name = name;
        Console.WriteLine($"Packaging: {name}.");
    }

    public void Process(string city) => Console.WriteLine($"Sending '{name}' to {city}.");
}

class DeliveryBox : Composite<string>, IDeliveryItem
{
    private readonly int len;
    private readonly int width;
    private readonly int height;

    public DeliveryBox(int len, int width, int height)
    {
        this.len = len;
        this.width = width;
        this.height = height;
        Console.WriteLine($"Packaging Box: {len}x{width}x{height} cms.");
    }

    public override void Process(string city)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Sending box '{len}x{width}x{height} cms' to {city}.");
        base.Process(city);
    }
}
```

```
// Output
Packaging: Bag.
Packaging: Shoes.
Packaging Box: 50x40x40 cms.
Packaging: Shirt.
Packaging: Pants.
Packaging Box: 40x30x20 cms.
Packaging Box: 100x80x60 cms.
----------------------------------------
Sending box '100x80x60 cms' to Berlin.
----------------------------------------
Sending box '50x40x40 cms' to Berlin.
Sending 'Bag' to Berlin.
Sending 'Shoes' to Berlin.
----------------------------------------
Sending box '40x30x20 cms' to Berlin.
Sending 'Shirt' to Berlin.
Sending 'Pants' to Berlin.
```

#### Full example

[CompositePatternExampleWithoutInput](./../../GofConsoleApp/Examples/Structural/CompositePattern/CompositePatternExampleWithoutInput.cs)


### Classes and interfaces used in example:

- [IComponent](./../../GofPatterns/Structural/CompositePattern/IComponent.cs)
- [ILeaf](./../../GofPatterns/Structural/CompositePattern/ILeaf.cs)
- [IComposite](./../../GofPatterns/Structural/CompositePattern/IComposite.cs)
- [Composite](./../../GofPatterns/Structural/CompositePattern/Composite.cs)

## Benefits

- It provides a way to treat individual objects and compositions of objects uniformly.
- It simplifies the client code by allowing the client to treat the individual objects and compositions of objects uniformly.

## Drawbacks

- It can make the design overly general. It can make the design overly general, and it may be difficult to restrict the type of objects that can be added to the composite.

## Similarity with other patterns

- The composite pattern is similar to the decorator pattern, but the composite pattern is used to create a tree structure of objects, where individual objects are treated as a single object, and compositions of objects are treated as a single object.
