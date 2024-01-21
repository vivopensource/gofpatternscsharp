# Abstract Factory Pattern

- Abstract Factory pattern is one of the Creational Design pattern and almost similar to Factory Pattern except the fact that its more like factory of factories.
- If you are familiar with factory design pattern in java, you will notice that we have a single Factory class that returns the different sub-classes based on the input provided and factory class uses if-else or switch statement to achieve this.

# Structure

- It consists of AbstractFactory, ConcreteFactory, AbstractProduct, ConcreteProduct and Client.
- AbstractFactory: An interface that will contain the methods for creating the products.
- ConcreteFactory: A class that will implement the AbstractFactory and will be responsible for creating the products.
- AbstractProduct: An interface that will contain the methods for the products.
- ConcreteProduct: A class that will implement the AbstractProduct and will be responsible for the products.
- Client: A class that will use the AbstractFactory and AbstractProduct interfaces for creating a family of related objects.

## Example

```csharp
// Factory items
interface ICar : IFactoryItem
{
    public string Name { get; }
    public string EngineType { get; }
    public string Fuel { get; }
}

class Hutchback : ICar
{
    public string Name => nameof(Hutchback);
    public string EngineType => "V6";
    public string Fuel => "Diesel";
}

class Sedan : ICar
{
    public string Name => nameof(Sedan);
    public string EngineType => "V8";
    public string Fuel => "Petrol";
}

// Factories
interface ICarFactory : IFactory<ICar> { }

class HutchbackFactory : IFactory<ICar>
{
    public ICar Create() => new Hutchback();
}

class SedanFactory : IFactory<ICar>
{
    public ICar Create() => new Sedan();
}

// Pattern execution
var factory = new CarFactory();
ICar car = factory.Create(nameof(Hutchback));
Console.WriteLine($"Car: {car.Name}, Engine type: {car.EngineType}, Fuel: {car.Fuel}");
car = factory.Create(nameof(Sedan));
Console.WriteLine($"Car: {car.Name}, Engine type: {car.EngineType}, Fuel: {car.Fuel}");
```
```
// Output
Car: Hutchback, Engine type: V6, Fuel: Diesel
Car: Sedan, Engine type: V8, Fuel: Petrol
```

#### Full example

[AbstractFactoryPatternExample](./../../GofConsoleApp/Examples/Creational/AbstractFactoryPattern/AbstractFactoryPatternExample.cs)

### Classes and interfaces used in example:
- [IFactoryItem](./../../GofPatterns/Creational/AbstractFactoryPattern/IFactoryItem.cs)
- [IFactory](./../../GofPatterns/Creational/AbstractFactoryPattern/IFactory.cs)
- [IBaseFactory](./../../GofPatterns/Creational/AbstractFactoryPattern/IBaseFactory.cs)
- [BaseFactory](./../../GofPatterns/Creational/AbstractFactoryPattern/BaseFactory.cs)

## Benefits

- Abstract Factory pattern provides approach to code for interface rather than implementation.
- Abstract Factory pattern is “factory of factories” and can be easily extended to accommodate more products, for example we can add another sub-class SUV and a factory SUVFactory.

## Similarity with other patterns

- It is similar to the factory pattern, but the factory pattern is used to create the objects of a single type.