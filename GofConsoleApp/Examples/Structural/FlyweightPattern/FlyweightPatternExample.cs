using GofConsoleApp.Examples.Structural.FlyweightPattern.Components;
using GofPatterns.Structural.FlyweightPattern;

namespace GofConsoleApp.Examples.Structural.FlyweightPattern;

internal class FlyweightPatternExample : BaseExample
{
    protected override bool Execute()
    {
        IShape circle = new CircleShape(Logger);
        IShape square = new SquareShape(Logger);

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

        Logger.Log($"Is circleObj1 same as circleObj2? {circleObj1 == circleObj2}");
        Logger.Log($"Is squareObj1 same as squareObj2? {squareObj1 == squareObj2}");

        return true;
    }
}