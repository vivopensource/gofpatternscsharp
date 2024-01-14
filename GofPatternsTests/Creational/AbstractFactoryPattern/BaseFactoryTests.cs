using GofConsoleApp.Examples.Creational.AbstractFactoryPattern.Components;
using GofPatterns.Creational.AbstractFactoryPattern;
using NUnit.Framework;

namespace GofPatternsTests.Creational.AbstractFactoryPattern;

[TestFixture]
internal class BaseFactoryTests
{
    [Test]
    public void Create_WhenCalled_ReturnsFactoryItem()
    {
        // arrange
        var baseFactory = new BaseFactory<IFactory<ICar>, ICar>();
        ICarFactory sedanFactory = new SedanFactory();

        // act
        var actualResult = baseFactory.Create(sedanFactory);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(actualResult.Name, Is.EqualTo("Sedan"));
            Assert.That(actualResult.EngineType, Is.EqualTo("V8"));
            Assert.That(actualResult.Fuel, Is.EqualTo("Petrol"));
        });
    }
}