using Core.Console.Interfaces;
using Core.Extensions;
using GofPatterns.Structural.FlyweightPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.FlyweightPattern.Components;

internal interface IShape : IFlyweight<CoOrdinates> { }

internal class CircleShape : IShape
{
    private readonly IConsoleLogger logger;

    public CircleShape(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Action(CoOrdinates points)
    {
        logger.Log("Drawing circle at co-ordinates:");
        logger.Log(points.ToYamlString());
    }
}

internal class SquareShape : IShape
{
    private readonly IConsoleLogger logger;

    public SquareShape(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Action(CoOrdinates points)
    {
        logger.Log("Drawing square at co-ordinates:");
        logger.Log(points.ToYamlString());
    }
}