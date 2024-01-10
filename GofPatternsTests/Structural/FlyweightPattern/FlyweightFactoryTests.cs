using Core.Console.Interfaces;
using GofConsoleApp.Examples.Structural.FlyweightPattern;
using GofConsoleApp.Examples.Structural.FlyweightPattern.Components;
using GofPatterns.Structural.FlyweightPattern;
using GofPatterns.Structural.FlyweightPattern.Interfaces;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Structural.FlyweightPattern;

[TestFixture]
internal class FlyweightFactoryTests
{
    [TestCase(ShapeType.Circle, typeof(CircleShape))]
    public void GetObject_AcceptsFlyweightType_ReturnsObject(ShapeType inputType, Type expectedType)
    {
        IFlyweight<CoOrdinates> circle = new CircleShape(Mock.Of<IConsoleLogger>());
        IFlyweight<CoOrdinates> square = new SquareShape(Mock.Of<IConsoleLogger>());

        // arrange
        var sutFactory = new FlyweightFactory<ShapeType, CoOrdinates>
        (
            new FlyweightMapping<ShapeType, CoOrdinates>(ShapeType.Circle, circle),
            new FlyweightMapping<ShapeType, CoOrdinates>(ShapeType.Square, square)
        );

        // act
        var actualResult = sutFactory.GetObject(inputType);

        // assert
        Assert.That(actualResult.GetType(), Is.EqualTo(expectedType));
    }
}