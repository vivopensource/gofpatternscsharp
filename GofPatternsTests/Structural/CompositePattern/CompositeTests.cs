using GofConsoleApp.Examples.Structural.CompositePattern;
using GofPatterns.Structural.CompositePattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Structural.CompositePattern;

[TestFixture]
[TestOf(typeof(Composite))]
internal class CompositeTests : BaseTest
{
    private readonly IComposite sut = new Composite();

    [Test]
    public void Process_CallsProcessOnAllComponents()
    {
        // arrange
        sut.Add(new Employee("Test", MockConsoleLogger.Object));

        // act
        sut.Process();

        // assert
        MockConsoleLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void Pop_RemovesLastComponent()
    {
        // arrange
        sut.Add(new Employee("Test", MockConsoleLogger.Object));

        // act
        sut.Pop();
        sut.Process();

        // assert
        MockConsoleLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void Remove_TakesOutGivenComponent()
    {
        // arrange
        var employee = new Employee("Test", MockConsoleLogger.Object);
        sut.Add(employee);

        // act
        sut.Remove(employee);
        sut.Process();

        // assert
        MockConsoleLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void RemoveAll_TakesOutAllComponents()
    {
        // arrange
        var john = new Employee("John", MockConsoleLogger.Object);
        var jane = new Employee("Jane", MockConsoleLogger.Object);
        sut.Add(john, jane);

        // act
        sut.RemoveAll();
        sut.Process();

        // assert
        MockConsoleLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
    }
}