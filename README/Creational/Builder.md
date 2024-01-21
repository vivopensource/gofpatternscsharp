# Builder Pattern

- The builder pattern is a design pattern designed to provide a flexible solution to various object creation problems in object-oriented programming.
- The intent of the Builder design pattern is to separate the construction of a complex object from its representation.
- By doing so, the same construction process can create different representations.

## Structure

- It consists of builder, concrete builder, director and product.
- Builder: An abstract class that will contain the methods for building the product.
- Concrete Builder: A class that will implement the Builder and will be responsible for building the product.
- Director: A class that will use the Builder interface for building the product.
- Product: A class that will contain the actual implementation of the product.

## Example

```csharp
// Builder class
class AdditionBuilder : Builder<decimal>
{
    private decimal num;

    public override decimal Output() => num;

    protected override void Build(decimal input) => num = decimal.Add(num, input);

// Pattern execution
var builder = new AdditionBuilder();
builder.Append(1.2m).Append(2.4m).Append(3.6m);
Console.WriteLine($"Output: {builder.Output()}");
```
```
// Output
Output: 7.2
```

### Classes and interfaces used in example:
- [IBuilder](./../../GofPatterns/Creational/BuilderPattern/IBuilder.cs)
- [Builder](./../../GofPatterns/Creational/BuilderPattern/Builder.cs)

## Benefits

- The parameters to the constructor are reduced and are provided in highly readable method calls.
- Object is always instantiated in a complete state.
- The builder pattern helps to avoid the inconsistent state problem.

## Similarity with other patterns

- Builder pattern is similar to the [Abstract Factory](./../../GofPatterns/Creational/AbstractFactoryPattern/README.md) pattern in that, both create complex objects.
- The difference is that the Builder pattern focuses on constructing a complex object step by step whereas the [Abstract Factory](./../../GofPatterns/Creational/AbstractFactoryPattern/README.md) pattern focuses on families of related objects.
- The Builder pattern returns the product as a final step, but as far as the Abstract Factory pattern is concerned, the product gets returned immediately.