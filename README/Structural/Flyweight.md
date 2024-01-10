
# Flyweight Pattern

- The flyweight pattern is used to reduce the memory usage by sharing the common data with other similar objects.
- It is used when we need to create a large number of similar objects.
- It is used to improve the performance of the application.
- It is used to reduce the memory footprint of the application.

## Structure

- It consists of flyweight, flyweight factory, flyweight mapping and client (client does pattern execution).
- Flyweight: An interface that will be implemented by the concrete flyweight class.
- Flyweight Factory: A factory class that will create the flyweight objects.
- Flyweight Mapping: A mapping class that will map the flyweight objects with the key.
- Client: A client class that will use the flyweight objects.

## Examples

```csharp
// Object type
internal enum ShapeType
{
    Circle,
    Square
}

// Flyweight class
interface IShape : IFlyweight<CoOrdinates> { }

class Circle : IShape
{
    public void Action(CoOrdinates points)
    {
        Console.Write("Drawing circle at co-ordinate => ");
        Console.WriteLine($"X1:{points.X1}, X2:{points.X2}, Y1:{points.Y1}, Y2:{points.Y2}");
    }
}

class Square : IShape
{
    public void Action(CoOrdinates points)
    {
        Console.Write("Drawing square at co-ordinate => ");
        Console.WriteLine($"X1:{points.X1}, X2:{points.X2}, Y1:{points.Y1}, Y2:{points.Y2}");
    }
}

// Object input
class CoOrdinates
{
    public int X1 { get; set; }
    public int X2 { get; set; }
    public int Y1 { get; set; }
    public int Y2 { get; set; }
}

// Client - Pattern execution
IFlyweight<CoOrdinates> circle = new Circle();
IFlyweight<CoOrdinates> square = new Square();

IFlyweightFactory<ShapeType, CoOrdinates> factory = new FlyweightFactory<ShapeType, CoOrdinates>
(
    new FlyweightMapping<ShapeType, CoOrdinates>(ShapeType.Circle, circle),
    new FlyweightMapping<ShapeType, CoOrdinates>(ShapeType.Square, square)
);

var circleObj1 = factory.GetObject(ShapeType.Circle);
circleObj1.Action(new CoOrdinates { X1 = 1, X2 = 2, Y1 = 3, Y2 = 4 });

var squareObj1 = factory.GetObject(ShapeType.Square);
squareObj1.Action(new CoOrdinates { X1 = 5, X2 = 6, Y1 = 7, Y2 = 8 });

var circleObj2 = factory.GetObject(ShapeType.Circle);
circleObj2.Action(new CoOrdinates { X1 = 9, X2 = 10, Y1 = 11, Y2 = 12 });

var squareObj2 = factory.GetObject(ShapeType.Square);
squareObj2.Action(new CoOrdinates { X1 = 5, X2 = 6, Y1 = 7, Y2 = 8 });

Console.WriteLine($"Is circleObj1 same as circleObj2? {circleObj1 == circleObj2}");
Console.WriteLine($"Is squareObj1 same as squareObj2? {squareObj1 == squareObj2}");
```

```
// Output
Drawing circle at co-ordinate => X1:1, X2:2, Y1:3, Y2:4
Drawing square at co-ordinate => X1:5, X2:6, Y1:7, Y2:8
Drawing circle at co-ordinate => X1:9, X2:10, Y1:11, Y2:12
Drawing square at co-ordinate => X1:5, X2:6, Y1:7, Y2:8
Is circleObj1 same as circleObj2? True
Is squareObj1 same as squareObj2? True

```
#### Full example

[FlyweightPatternExample](./../../GofConsoleApp/Examples/Structural/FlyweightPattern/FlyweightPatternExample.cs)

## Benefits

- It reduces the memory usage by sharing the common data with other similar objects.
- It improves the performance of the application.
- It reduces the memory footprint of the application.

## Similarity with other patterns

- It is similar to the object pool pattern, but the object pool pattern is used to manage the object instances.
- It is similar to the prototype pattern, but the prototype pattern is used to create the new object instances.
- It is similar to the singleton pattern, but the singleton pattern is used to create the single object instance.
- It is similar to the factory pattern, but the factory pattern is used to create the new objects.