# Factory Pattern

- Factory pattern is one of the most used design patterns in Java. This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.
- In Factory pattern, we create object without exposing the creation logic to the client and refer to newly created object using a common interface.

## Structure

- It consists of factory, product and client.
- Factory: An interface that will contain the method to be implemented by the concrete component and decorator.
- Product: A class that will contain the reference to the component and will implement the same interface implemented by the component so that it can be used by the client.
- Client: A class that will contain the actual implementation of the method.

## Example

```csharp
// Factory items
interface ICar : IFactoryItem
{
    public string Name { get; }
    public string EngineType { get; }
    public string Fuel { get; }
}

class Hatchback : ICar
{
    public string Name => nameof(Hatchback);
    public string EngineType => "V6";
    public string Fuel => "Diesel";
}

class Sedan : ICar
{
    public string Name => nameof(Sedan);
    public string EngineType => "V8";
    public string Fuel => "Petrol";
}

// Factory
class CarFactory : IFactory<string, ICar>
{
    public ICar Create(string input) =>
        input switch
        {
            nameof(Hatchback) => new Hatchback(),
            nameof(Sedan) => new Sedan()
        };
}

// Pattern execution
var factory = new CarFactory();
ICar hatchbackCar = factory.Create(nameof(Hatchback));
Console.WriteLine($"Car: {hatchbackCar.Name}, Engine type: {hatchbackCar.EngineType}, Fuel: {hatchbackCar.Fuel}");
ICar sedanCar = factory.Create(nameof(Sedan));
Console.WriteLine($"Car: {sedanCar.Name}, Engine type: {sedanCar.EngineType}, Fuel: {sedanCar.Fuel}");
```
```
// Output
Car: Hatchback, Engine type: V6, Fuel: Diesel
Car: Sedan, Engine type: V8, Fuel: Petrol
```
Classes and interfaces used in code:
- [IFactoryItem](./../../GofPatterns/Creational/FactoryPattern/IFactoryItem.cs)
- [IFactory](./../../GofPatterns/Creational/FactoryPattern/IFactory.cs)

#### Full example

- [FactoryPatternExample](./../../GofConsoleApp/Examples/Creational/FactoryPattern/FactoryPatternExample.cs)

## Benefits

- Factory pattern provides approach to code for interface rather than implementation.
- Factory pattern removes the instantiation of actual implementation classes from client code. Factory pattern makes our code more robust, less coupled and easy to extend. For example, we can easily change PC class implementation because client program is unaware of this.

## Similarity with other patterns

- Factory pattern is similar to Abstract Factory pattern in a way that both factory are abstraction and create objects, but they are different in terms of their intention. Abstract Factory pattern is used to create families of related or dependent objects where as Factory pattern is used to create the instance of one of the several possible classes.